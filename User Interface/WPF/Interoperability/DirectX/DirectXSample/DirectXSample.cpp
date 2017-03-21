//-----------------------------------------------------------------------------
// Modified version of the "Meshes" sample from the DirectX SDK.
// Copyright (c) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#include <Windows.h>
#include <d3dx9.h>

//-----------------------------------------------------------------------------
// Global variables
//-----------------------------------------------------------------------------
LPDIRECT3D9 g_pD3D = nullptr;
LPDIRECT3DDEVICE9 g_pd3dDevice = nullptr;
LPDIRECT3DSURFACE9 g_pd3dSurface = nullptr;
LPD3DXMESH g_pMesh = nullptr;
D3DMATERIAL9* g_pMeshMaterials = nullptr;
LPDIRECT3DTEXTURE9* g_pMeshTextures = nullptr;
DWORD g_dwNumMaterials = 0L;

//-----------------------------------------------------------------------------
// Name: InitD3D()
// Desc: Initializes Direct3D
//-----------------------------------------------------------------------------
HRESULT InitD3D(HWND hWnd)
{
   // For Windows Vista or later, this would be better if it used Direct3DCreate9Ex:
   if (NULL == (g_pD3D = Direct3DCreate9(D3D_SDK_VERSION)))
      return E_FAIL;

   // Set up the structure used to create the D3DDevice. Since we are now
   // using more complex geometry, we will create a device with a zbuffer.
   D3DPRESENT_PARAMETERS d3dpp;
   ZeroMemory(&d3dpp, sizeof(d3dpp));
   d3dpp.Windowed = TRUE;
   d3dpp.SwapEffect = D3DSWAPEFFECT_DISCARD;
   d3dpp.BackBufferFormat = D3DFMT_UNKNOWN;
   d3dpp.EnableAutoDepthStencil = TRUE;
   d3dpp.AutoDepthStencilFormat = D3DFMT_D16;

   // Create the D3DDevice
   if (FAILED(g_pD3D->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, hWnd,
      D3DCREATE_SOFTWARE_VERTEXPROCESSING,
      &d3dpp, &g_pd3dDevice)))
   {
      return E_FAIL;
   }

   // Turn on the zbuffer
   g_pd3dDevice->SetRenderState(D3DRS_ZENABLE, TRUE);

   // Turn on ambient lighting 
   g_pd3dDevice->SetRenderState(D3DRS_AMBIENT, 0xffffffff);

   return S_OK;
}

//-----------------------------------------------------------------------------
// Name: InitGeometry()
// Desc: Load the mesh and build the material and texture arrays
//-----------------------------------------------------------------------------
HRESULT InitGeometry()
{
   LPD3DXBUFFER pD3DXMtrlBuffer;

   // Load the mesh from the specified file
   if (FAILED(D3DXLoadMeshFromX(L"Tiger.x", D3DXMESH_SYSTEMMEM,
      g_pd3dDevice, NULL,
      &pD3DXMtrlBuffer, NULL, &g_dwNumMaterials,
      &g_pMesh)))
   {
      MessageBox(nullptr, L"Could not find tiger.x", L"Meshes.exe", MB_OK);
      return E_FAIL;
   }

   // We need to extract the material properties and texture names from the 
   // pD3DXMtrlBuffer
   auto d3dxMaterials = static_cast<D3DXMATERIAL*>(pD3DXMtrlBuffer->GetBufferPointer());
   g_pMeshMaterials = new D3DMATERIAL9[g_dwNumMaterials];
   if (g_pMeshMaterials == nullptr)
      return E_OUTOFMEMORY;

   g_pMeshTextures = new LPDIRECT3DTEXTURE9[g_dwNumMaterials];
   if (g_pMeshTextures == nullptr)
      return E_OUTOFMEMORY;

   for (DWORD i = 0; i < g_dwNumMaterials; i++)
   {
      // Copy the material
      g_pMeshMaterials[i] = d3dxMaterials[i].MatD3D;

      // Set the ambient color for the material (D3DX does not do this)
      g_pMeshMaterials[i].Ambient = g_pMeshMaterials[i].Diffuse;

      g_pMeshTextures[i] = nullptr;
      if (d3dxMaterials[i].pTextureFilename != nullptr &&
         lstrlenA(d3dxMaterials[i].pTextureFilename) > 0)
      {
         // Create the texture
         if (FAILED(D3DXCreateTextureFromFileA(g_pd3dDevice,
            d3dxMaterials[i].pTextureFilename,
            &g_pMeshTextures[i])))
         {
            // If texture is not in current folder, try parent folder
            const CHAR* strPrefix = "..\\";
            CHAR strTexture[MAX_PATH];
            strcpy_s(strTexture, MAX_PATH, strPrefix);
            strcat_s(strTexture, MAX_PATH, d3dxMaterials[i].pTextureFilename);
            // If texture is not in current folder, try parent folder
            if (FAILED(D3DXCreateTextureFromFileA(g_pd3dDevice,
               strTexture,
               &g_pMeshTextures[i])))
            {
               MessageBox(nullptr, L"Could not find texture map", L"Meshes.exe", MB_OK);
            }
         }
      }
   }

   // Done with the material buffer
   pD3DXMtrlBuffer->Release();

   return S_OK;
}

//-----------------------------------------------------------------------------
// Name: Initialize()
// Desc: Initializes DirectX, the scene, geometry, and more.
//-----------------------------------------------------------------------------
extern "C" __declspec(dllexport) IDirect3DSurface9* WINAPI Initialize(HWND hwnd, int width, int height)
{
   // Initialize Direct3D + Create the scene geometry
   if (SUCCEEDED(InitD3D(hwnd)) && SUCCEEDED(InitGeometry()))
   {
      if (FAILED(g_pd3dDevice->CreateRenderTarget(width, height,
         D3DFMT_A8R8G8B8, D3DMULTISAMPLE_NONE, 0,
         true, // lockable (true for compatibility with Windows XP.  False is preferred for Windows Vista or later)
         &g_pd3dSurface, NULL)))
      {
         MessageBox(nullptr, L"NULL!", L"Missing File", 0);
         return nullptr;
      }

      g_pd3dDevice->SetRenderTarget(0, g_pd3dSurface);
   }

   return g_pd3dSurface;
}

//-----------------------------------------------------------------------------
// Name: Cleanup()
// Desc: Releases all previously initialized objects
//-----------------------------------------------------------------------------
extern "C" __declspec(dllexport) VOID WINAPI Cleanup()
{
   if (g_pMeshMaterials != nullptr)
      delete[] g_pMeshMaterials;

   if (g_pMeshTextures)
   {
      for (DWORD i = 0; i < g_dwNumMaterials; i++)
      {
         if (g_pMeshTextures[i])
            g_pMeshTextures[i]->Release();
      }

      delete[] g_pMeshTextures;
   }

   if (g_pMesh != nullptr)
      g_pMesh->Release();

   if (g_pd3dDevice != nullptr)
      g_pd3dDevice->Release();

   if (g_pD3D != nullptr)
      g_pD3D->Release();
}

//-----------------------------------------------------------------------------
// Name: SetupMatrices()
// Desc: Sets up the world, view, and projection transform matrices.
//-----------------------------------------------------------------------------
VOID SetupMatrices()
{
   // Set up world matrix
   D3DXMATRIXA16 matWorld;
   D3DXMatrixRotationY(&matWorld, timeGetTime() / 1000.0f);
   g_pd3dDevice->SetTransform(D3DTS_WORLD, &matWorld);

   // Set up our view matrix. A view matrix can be defined given an eye point,
   // a point to lookat, and a direction for which way is up. Here, we set the
   // eye five units back along the z-axis and up three units, look at the 
   // origin, and define "up" to be in the y-direction.
   D3DXVECTOR3 vEyePt(0.0f, 3.0f, -5.0f);
   D3DXVECTOR3 vLookatPt(0.0f, 0.0f, 0.0f);
   D3DXVECTOR3 vUpVec(0.0f, 1.0f, 0.0f);
   D3DXMATRIXA16 matView;
   D3DXMatrixLookAtLH(&matView, &vEyePt, &vLookatPt, &vUpVec);
   g_pd3dDevice->SetTransform(D3DTS_VIEW, &matView);

   // For the projection matrix, we set up a perspective transform (which
   // transforms geometry from 3D view space to 2D viewport space, with
   // a perspective divide making objects smaller in the distance). To build
   // a perpsective transform, we need the field of view (1/4 pi is common),
   // the aspect ratio, and the near and far clipping planes (which define at
   // what distances geometry should be no longer be rendered).
   D3DXMATRIXA16 matProj;
   D3DXMatrixPerspectiveFovLH(&matProj, D3DX_PI / 4, 1.0f, 1.0f, 100.0f);
   g_pd3dDevice->SetTransform(D3DTS_PROJECTION, &matProj);
}

//-----------------------------------------------------------------------------
// Name: Render()
// Desc: Draws the scene
//-----------------------------------------------------------------------------
extern "C" __declspec(dllexport) VOID WINAPI Render()
{
   // Clear the backbuffer and the zbuffer
   g_pd3dDevice->Clear(0, nullptr, D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER,
                       D3DCOLOR_XRGB(0, 0, 0), 1.0f, 0);

   // Begin the scene
   if (SUCCEEDED(g_pd3dDevice->BeginScene()))
   {
      // Setup the world, view, and projection matrices
      SetupMatrices();

      // Meshes are divided into subsets, one for each material. Render them in
      // a loop
      for (DWORD i = 0; i < g_dwNumMaterials; i++)
      {
         // Set the material and texture for this subset
         g_pd3dDevice->SetMaterial(&g_pMeshMaterials[i]);
         g_pd3dDevice->SetTexture(0, g_pMeshTextures[i]);

         // Draw the mesh subset
         g_pMesh->DrawSubset(i);
      }

      // End the scene
      g_pd3dDevice->EndScene();
   }
}
