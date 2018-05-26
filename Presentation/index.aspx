<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Presentation.Site.HomeSite" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Home</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Home</p></div>
	<div class="headRight">
        <asp:DropDownList id="ddTable" runat="server" OnClick="Add" ToolTip="Add one or more client(s)" BackColor="White">
            <asp:ListItem Selected="True">All</asp:ListItem> 
            <asp:ListItem>CRA</asp:ListItem> 
            <asp:ListItem>Client</asp:ListItem> 
            <asp:ListItem>Client Contract</asp:ListItem> 
            <asp:ListItem>Department</asp:ListItem> 
            <asp:ListItem>Doctor</asp:ListItem> 
            <asp:ListItem>Evaluation</asp:ListItem> 
            <asp:ListItem>Hospital</asp:ListItem> 
            <asp:ListItem>Project Manager</asp:ListItem> 
            <asp:ListItem>Project</asp:ListItem> 
            <asp:ListItem>Study Coordinators</asp:ListItem> 
        </asp:DropDownList>
        <asp:TextBox id="TbSearch" runat="server" OnClick="Edit" Tooltip="Edit selected row(s)" BackColor="White" OnTextChanged="TbSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
	</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <asp:Table ID="buttonTable" runat="server" CssClass="homeTable">
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="CRA" OnClick="ButtonCRA_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Client" OnClick="ButtonClient_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Client Contract" OnClick="ButtonClientContract_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Department" OnClick="ButtonDepartment_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Doctor" OnClick="ButtonDoctor_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Evaluation" OnClick="ButtonEvaluation_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Hospital" OnClick="ButtonHospital_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Project Manager" OnClick="ButtonProjectManager_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Project" OnClick="ButtonProject_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell"></asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <asp:Button runat="server" autopostback="true" CssClass="homeImageButton" Text="Study Coordinator" OnClick="ButtonStudyCoordinator_Click"/>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="resultTable" runat="server" CssClass="homeTable">
        <asp:TableRow ID="rowCRAText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">CRA's</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowCRAgrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvCRA">
                    <Columns>
            <asp:TemplateField ShowHeader="false" HeaderStyle-Width="50px" >
                <ItemTemplate>
                    <label class="container">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                        <span class="checkmark"></span>
                    </label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="CV" HeaderText="CV" />
            <asp:BoundField DataField="Email" HeaderText="E-mail" />
            <asp:BoundField DataField="Phone1" HeaderText="Phone 1" />
            <asp:BoundField DataField="Phone2" HeaderText="Phone 2" />
        </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>