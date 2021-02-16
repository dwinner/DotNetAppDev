﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using System;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;

namespace AppDevUnited.TaskFlowDSLSample
{
	/// <summary>
	/// Helper class used to create and initialize toolbox items for this DSL.
	/// </summary>
	/// <remarks>
	/// Double-derived class to allow easier code customization.
	/// </remarks>
	public partial class TaskFlowDSLSampleToolboxHelper : TaskFlowDSLSampleToolboxHelperBase 
	{
		/// <summary>
		/// Constructs a new TaskFlowDSLSampleToolboxHelper.
		/// </summary>
		public TaskFlowDSLSampleToolboxHelper(global::System.IServiceProvider serviceProvider)
			: base(serviceProvider) { }
	}
	
	/// <summary>
	/// Helper class used to create and initialize toolbox items for this DSL.
	/// </summary>
	
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "The store is disposed on domain shut down")]
	public abstract class TaskFlowDSLSampleToolboxHelperBase
	{
		/// <summary>
		/// Toolbox item filter string used to identify TaskFlowDSLSample toolbox items.  
		/// </summary>
		/// <remarks>
		/// See the MSDN documentation for the ToolboxItemFilterAttribute class for more information on toolbox
		/// item filters.
		/// </remarks>
		public const string ToolboxFilterString = "TaskFlowDSLSample.1.0";
		/// <summary>
		/// Toolbox item filter string used to identify Flow connector tool.
		/// </summary>
		public const string FlowFilterString = "Flow.1.0";
		/// <summary>
		/// Toolbox item filter string used to identify CommentSubjects connector tool.
		/// </summary>
		public const string CommentSubjectsFilterString = "CommentSubjects.1.0";

	
		private global::System.Collections.Generic.Dictionary<string, DslDesign::ModelingToolboxItem> toolboxItemCache = new global::System.Collections.Generic.Dictionary<string, DslDesign::ModelingToolboxItem>();
		private DslModeling::Store toolboxStore;
		
		private global::System.IServiceProvider sp;
		
		/// <summary>
		/// Constructs a new TaskFlowDSLSampleToolboxHelperBase.
		/// </summary>
		protected TaskFlowDSLSampleToolboxHelperBase(global::System.IServiceProvider serviceProvider)
		{
			if(serviceProvider == null) throw new global::System.ArgumentNullException("serviceProvider");
			
			this.sp = serviceProvider;
		}
		
		/// <summary>
		/// Serivce provider used to access services from the hosting environment.
		/// </summary>
		protected global::System.IServiceProvider ServiceProvider
		{
			get
			{
				return this.sp;
			}
		}

		/// <summary>
		/// Returns the display name of the tab that should be opened by default when the editor is opened.
		/// </summary>
		public static string DefaultToolboxTabName
		{
			get
			{
				return global::AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel.SingletonResourceManager.GetString("TaskFlowDSLSampleToolboxTab", global::System.Globalization.CultureInfo.CurrentUICulture);
			}
		}
		
		
		/// <summary>
		/// Returns the toolbox items count in the default tool box tab.
		/// </summary>
		public static int DefaultToolboxTabToolboxItemsCount
		{
			get
			{
				return 10;
			}
		}
		

		/// <summary>
		/// Returns a list of custom toolbox items to be added dynamically
		/// </summary>
		public virtual global::System.Collections.Generic.IList<DslDesign::ModelingToolboxItem> CreateToolboxItems()
		{
			global::System.Collections.Generic.List<DslDesign::ModelingToolboxItem> toolboxItems = new global::System.Collections.Generic.List<DslDesign::ModelingToolboxItem>();
			return toolboxItems;
		}
		
		/// <summary>
		/// Creates an ElementGroupPrototype for the element tool corresponding to the given domain class id.
		/// Default behavior is to create a prototype containing an instance of the domain class.
		/// Derived classes may override this to add additional information to the prototype.
		/// </summary>
		protected virtual DslModeling::ElementGroupPrototype CreateElementToolPrototype(DslModeling::Store store, global::System.Guid domainClassId)
		{
			DslModeling::ModelElement element = store.ElementFactory.CreateElement(domainClassId);
			DslModeling::ElementGroup elementGroup = new DslModeling::ElementGroup(store.DefaultPartition);
			elementGroup.AddGraph(element, true);
			return elementGroup.CreatePrototype();
		}

		/// <summary>
		/// Returns instance of ModelingToolboxItem based on specified name.
		/// This method must be called from within a Transaction. Failure to do so will result in an exception
		/// </summary>
		/// <param name="itemId">unique name of desired ToolboxItem</param>
		/// <param name="store">Store to perform the operation against</param>
		/// <returns>An instance of ModelingToolboxItem if the itemId can be resolved, null otherwise</returns>
		public virtual DslDesign::ModelingToolboxItem GetToolboxItem(string itemId, DslModeling::Store store)
		{
			DslDesign::ModelingToolboxItem result = null;
			if (string.IsNullOrEmpty(itemId))
			{
				return null;
			}
			if (store == null)
			{
				return null;
			}
			global::System.Resources.ResourceManager resourceManager = global::AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel.SingletonResourceManager;
			global::System.Globalization.CultureInfo resourceCulture = global::System.Globalization.CultureInfo.CurrentUICulture;
			switch(itemId)
			{
				case "AppDevUnited.TaskFlowDSLSample.TaskToolboxItem":
					// Add Task shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"AppDevUnited.TaskFlowDSLSample.TaskToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						1, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("TaskToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("TaskToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("TaskFlowDSLSampleToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"CreateTaskF1Keyword", // F1 help keyword for the toolbox item.
						resourceManager.GetString("TaskToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::AppDevUnited.TaskFlowDSLSample.Task.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "AppDevUnited.TaskFlowDSLSample.StartPointToolboxItem":
					// Add StartPoint shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"AppDevUnited.TaskFlowDSLSample.StartPointToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						2, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("StartPointToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("StartPointToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("TaskFlowDSLSampleToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"CreateStartStateF1Keyword", // F1 help keyword for the toolbox item.
						resourceManager.GetString("StartPointToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::AppDevUnited.TaskFlowDSLSample.StartPoint.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "AppDevUnited.TaskFlowDSLSample.EndPointToolboxItem":
					// Add EndPoint shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"AppDevUnited.TaskFlowDSLSample.EndPointToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						3, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("EndPointToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("EndPointToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("TaskFlowDSLSampleToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"CreateFinalStateF1Keyword", // F1 help keyword for the toolbox item.
						resourceManager.GetString("EndPointToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::AppDevUnited.TaskFlowDSLSample.Endpoint.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "AppDevUnited.TaskFlowDSLSample.MergeBranchToolboxItem":
					// Add MergeBranch shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"AppDevUnited.TaskFlowDSLSample.MergeBranchToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						4, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("MergeBranchToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("MergeBranchToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("TaskFlowDSLSampleToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"CreateMergeBranchF1Keyword", // F1 help keyword for the toolbox item.
						resourceManager.GetString("MergeBranchToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::AppDevUnited.TaskFlowDSLSample.MergeBranch.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "AppDevUnited.TaskFlowDSLSample.SynchronizationToolboxItem":
					// Add Synchronization shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"AppDevUnited.TaskFlowDSLSample.SynchronizationToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						5, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("SynchronizationToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("SynchronizationToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("TaskFlowDSLSampleToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"Synchronization", // F1 help keyword for the toolbox item.
						resourceManager.GetString("SynchronizationToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::AppDevUnited.TaskFlowDSLSample.Synchronization.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "AppDevUnited.TaskFlowDSLSample.FlowToolboxItem":

					// Add Flow connector tool.
					result = new DslDesign::ModelingToolboxItem(
						"AppDevUnited.TaskFlowDSLSample.FlowToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						6, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("FlowToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("FlowToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.				
						"AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("TaskFlowDSLSampleToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"ConnectFlowF1Keyword", // F1 help keyword for the toolbox item.
						resourceManager.GetString("FlowToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						null, // Connector toolbox items do not have an underlying data object.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
							new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require), 
							new global::System.ComponentModel.ToolboxItemFilterAttribute(FlowFilterString)
						});
					break;
				case "AppDevUnited.TaskFlowDSLSample.ObjectInStateToolboxItem":
					// Add ObjectInState shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"AppDevUnited.TaskFlowDSLSample.ObjectInStateToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						7, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("ObjectInStateToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ObjectInStateToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("TaskFlowDSLSampleToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"CreateObjectInStateF1Keyword", // F1 help keyword for the toolbox item.
						resourceManager.GetString("ObjectInStateToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::AppDevUnited.TaskFlowDSLSample.ObjectInState.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "AppDevUnited.TaskFlowDSLSample.CommentToolboxItem":
					// Add Comment shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"AppDevUnited.TaskFlowDSLSample.CommentToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						8, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("CommentToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("CommentToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("TaskFlowDSLSampleToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"CreateCommentF1Keyword", // F1 help keyword for the toolbox item.
						resourceManager.GetString("CommentToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::AppDevUnited.TaskFlowDSLSample.Comment.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "AppDevUnited.TaskFlowDSLSample.CommentSubjectsToolboxItem":

					// Add CommentSubjects connector tool.
					result = new DslDesign::ModelingToolboxItem(
						"AppDevUnited.TaskFlowDSLSample.CommentSubjectsToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						9, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("CommentSubjectsToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("CommentSubjectsToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.				
						"AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("TaskFlowDSLSampleToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"ConnectCommentSubjectsF1Keyword", // F1 help keyword for the toolbox item.
						resourceManager.GetString("CommentSubjectsToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						null, // Connector toolbox items do not have an underlying data object.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
							new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require), 
							new global::System.ComponentModel.ToolboxItemFilterAttribute(CommentSubjectsFilterString)
						});
					break;
				case "AppDevUnited.TaskFlowDSLSample.ActorToolboxItem":
					// Add Actor shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"AppDevUnited.TaskFlowDSLSample.ActorToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						10, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("ActorToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ActorToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("TaskFlowDSLSampleToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"Actor", // F1 help keyword for the toolbox item.
						resourceManager.GetString("ActorToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::AppDevUnited.TaskFlowDSLSample.Actor.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				default:
					break;
			} // end switch
			
			return result;
		}
		

		/// <summary>
		/// The store toe be used for all the toolbox item creation
		/// </summary>
		protected DslModeling::Store ToolboxStore
		{
			get
			{ 
				if (toolboxStore==null)
				{
					toolboxStore = new DslModeling::Store(this.ServiceProvider);
					EventHandler StoreCleanUp = (o, e) =>
					{
						//Since Store implements IDisposable, we need to dispose it when we're finished
						if (this.toolboxStore != null)
						{
							this.toolboxStore.Dispose();
						}
						this.toolboxStore = null;
					};
					//There is no DomainUnload event for the default AppDomain, so we listen for both ProcessExit and DomainUnload
					AppDomain.CurrentDomain.ProcessExit += new EventHandler(StoreCleanUp);
					AppDomain.CurrentDomain.DomainUnload += new EventHandler(StoreCleanUp);
					
					//load the domain model
					toolboxStore.LoadDomainModels(typeof(global::AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel));
					
				}
				return toolboxStore;
			}
		}
		
		/// <summary>
		/// Given a toolbox item "unique ID" returns the the toolbox item using cached dictionary
		/// </summary>
		/// <param name="itemId">The unique ToolboxItem to retrieve</param>
		private DslDesign::ModelingToolboxItem GetToolboxItem(string itemId)
		{
			DslDesign::ModelingToolboxItem item = null;

			if (!this.toolboxItemCache.TryGetValue(itemId, out item))
			{
				DslModeling::Store store = this.ToolboxStore;
				
				// Open transaction so we can create model elements corresponding to toolbox items.
				using (DslModeling::Transaction t = store.TransactionManager.BeginTransaction("CreateToolboxItems"))
				{
					// Retrieve the specified ToolboxItem from the DSL
					this.toolboxItemCache[itemId] = item = this.GetToolboxItem(itemId, store);
				}
			}

			return item;
		}
		
		/// <summary>
		/// Given a toolbox item "unique ID" and a data format identifier, returns the content of
		/// the data format. 
		/// </summary>
		/// <param name="itemId">The unique ToolboxItem to retrieve data for</param>
		/// <param name="format">The desired format of the resulting data</param>
		public virtual object GetToolboxItemData(string itemId, DataFormats.Format format)
		{
			DslDesign::ModelingToolboxItem item = null;

			global::System.Resources.ResourceManager resourceManager = global::AppDevUnited.TaskFlowDSLSample.TaskFlowDSLSampleDomainModel.SingletonResourceManager;
			global::System.Globalization.CultureInfo resourceCulture = global::System.Globalization.CultureInfo.CurrentUICulture;

			System.Windows.Forms.IDataObject tbxDataObj;

			//get the toolbox item
			item = GetToolboxItem(itemId);

			if (item != null)
			{
				ToolboxItemContainer container = new ToolboxItemContainer(item);
				tbxDataObj = container.ToolboxData;

				if (tbxDataObj.GetDataPresent(format.Name))
				{
					return tbxDataObj.GetData(format.Name);
				}
				else 
				{
					string invalidFormatString = resourceManager.GetString("UnsupportedToolboxFormat", resourceCulture);
					throw new InvalidOperationException(string.Format(resourceCulture, invalidFormatString, format.Name));
				}
			}

			string errorFormatString = resourceManager.GetString("UnresolvedToolboxItem", resourceCulture);
			throw new InvalidOperationException(string.Format(resourceCulture, errorFormatString, itemId));
		}		
	}
}