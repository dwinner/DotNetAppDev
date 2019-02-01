﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationViaValidationAttributes.aspx.cs" Inherits="ClientSide.Validation.ValidationViaValidationAttributes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Проверка достоверности с применением атрибутов</title>
    <style>
        th { text-align: left; }

        td[colspan="2"] {
            padding: 10px 0;
            text-align: center;
        }

        .input-validation-error { border: medium solid red; }

        .error { color: red; }
    </style>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script src="Scripts/jquery.validate.js"></script>
    <script src="Scripts/jquery.validate.unobtrusive.js"></script>
</head>
<body>
<form id="form1" runat="server">
    <div id="errorSummary" data-valmsg-summary="true" class="error">
        <ul>
            <li style="display: none;"></li>
        </ul>
    </div>
    <asp:ValidationSummary runat="server" CssClass="error"/>
    <table>
        <tr>
            <td>Name:</td>
            <td>
                <input id="Name" runat="server"
                       data-val="true" data-val-required="Provide a name"
                       data-val-length="Name are 5-20 characters"
                       data-val-length-min="5" data-val-length-max="20"/>
            </td>
        </tr>
        <tr>
            <td>Category</td>
            <td>
                <input id="Category" runat="server"
                       data-val="true" data-val-required="Provide a category"/>
            </td>
        </tr>
        <tr>
            <td>Price:</td>
            <td>
                <input id="Price" runat="server"
                       data-val="true" data-val-required="Provide a price"
                       data-val-range="Prices must be 1-100,000"
                       data-val-range-min="1" data-val-range-max="100000"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <input type="submit" value="Create" runat="server"/>
            </td>
        </tr>
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Category</th>
            <th>Price</th>
        </tr>
        <asp:Repeater runat="server" ItemType="ClientSide.Validation.Models.Product" SelectMethod="GetCreated">
            <ItemTemplate>
                <tr>
                    <td><%#: Item.ProductId %></td>
                    <td><%#: Item.Name %></td>
                    <td><%#: Item.Category %></td>
                    <td><%#: Item.Price.ToString("F2") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</form>
</body>
</html>