<%@ Page Title="" Language="C#" MasterPageFile="~/CliniresearchSite.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Presentation.Site.HomeSite" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Home</title>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
	<div class="headLeft"><p class="uppercase">Home</p></div>
	<div class="headRight">
        <asp:TextBox id="TbSearch" runat="server" OnClick="Edit" Tooltip="Edit selected row(s)" OnTextChanged="TbSearch_TextChanged" placeholder="Search..." AutoPostBack="true" BackColor="White" CssClass="sortTextbox"></asp:TextBox>
        <asp:DropDownList id="ddTable" runat="server" OnClick="Add" ToolTip="Add one or more client(s)" OnSelectedIndexChanged="DdTable_SelectedIndexChanged" AutoPostBack="true" BackColor="White">
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
            <asp:ListItem>Study Coordinator</asp:ListItem> 
        </asp:DropDownList>
	</div>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="Body" runat="server">
    <asp:Table ID="buttonTable" runat="server" CssClass="homeTable">
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <div class="homeDiv">
                    <asp:Button runat="server" autopostback="true" CssClass="homeButton" Text="CRA's" OnClick="ButtonCRA_Click"/>
                </div>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <div class="homeDiv">
                <asp:Button runat="server" autopostback="true" CssClass="homeButton" Text="Clients" OnClick="ButtonClient_Click"/>
                    </div>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <div class="homeDiv">
                <asp:Button runat="server" autopostback="true" CssClass="homeButton" Text="Client Contracts" OnClick="ButtonContract_Click"/>
                    </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <div class="homeDiv">
                <asp:Button runat="server" autopostback="true" CssClass="homeButton" Text="Departments" OnClick="ButtonDepartment_Click"/>
                    </div>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <div class="homeDiv">
                <asp:Button runat="server" autopostback="true" CssClass="homeButton" Text="Doctors" OnClick="ButtonDoctor_Click"/>
                    </div>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <div class="homeDiv">
                <asp:Button runat="server" autopostback="true" CssClass="homeButton" Text="Evaluations" OnClick="ButtonEvaluation_Click"/>
                    </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <div class="homeDiv">
                <asp:Button runat="server" autopostback="true" CssClass="homeButton" Text="Hospitals" OnClick="ButtonHospital_Click"/>
                    </div>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <div class="homeDiv">
                <asp:Button runat="server" autopostback="true" CssClass="homeButton" Text="Project Managers" OnClick="ButtonProjectManager_Click"/>
                    </div>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <div class="homeDiv">
                <asp:Button runat="server" autopostback="true" CssClass="homeButton" Text="Projects" OnClick="ButtonProject_Click"/>
                    </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="homeRow">
            <asp:TableCell CssClass="homeCell"></asp:TableCell>
            <asp:TableCell CssClass="homeCell">
                <div class="homeDiv">
                <asp:Button runat="server" autopostback="true" CssClass="homeButton" Text="Study Coordinators" OnClick="ButtonStudyCoordinator_Click"/>
                    </div>
            </asp:TableCell>
            <asp:TableCell CssClass="homeCell"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="resultTable" runat="server" Visible="false" CssClass="homeTable">

        <asp:TableRow ID="rowCRAText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">CRA's</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowCRAGrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvCRA" AutoGenerateColumns="false" DataKeyNames="CRA_ID" RowStyle-CssClass="gvtr">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-CssClass="gvtd" />
                        <asp:BoundField DataField="CV" HeaderText="CV" ItemStyle-CssClass="gvtd" />
                        <asp:BoundField DataField="Email" HeaderText="E-mail" ItemStyle-CssClass="gvtd" />
                        <asp:BoundField DataField="Phone1" HeaderText="Phone 1" ItemStyle-CssClass="gvtd" />
                        <asp:BoundField DataField="Phone2" HeaderText="Phone 2" ItemStyle-CssClass="gvtd" />
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowClientText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">Clients</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowClientGrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvClient" AutoGenerateColumns="false" DataKeyNames="Client_ID" RowStyle-CssClass="gvtr">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Adress" HeaderText="Adress" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="City" HeaderText="City" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Contact_Person" HeaderText="Contact Person" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Invoice_Info" HeaderText="Invoice Info" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Kind_of_Client" HeaderText="Kind of Client" ItemStyle-CssClass="gvtd"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowContractText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">Client Contracts</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowContractGrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvContract" AutoGenerateColumns="false" DataKeyNames="Contract_ID" RowStyle-CssClass="gvtr">
                    <Columns>
                        <asp:BoundField DataField="Legal_country" HeaderText="Legal Country" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Fee" HeaderText="Fee" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Start_Date" HeaderText="Start Date" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="End_Date" HeaderText="End Date" ItemStyle-CssClass="gvtd"/>
                        <asp:TemplateField HeaderText="Project" ItemStyle-CssClass="gvtd">
                            <ItemTemplate>
                                <asp:Label ID="lbProject" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client" ItemStyle-CssClass="gvtd">
                            <ItemTemplate>
                                <asp:Label ID="lbClient" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowDepartmentText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">Departments</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowDepartmentGrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvDepartment" AutoGenerateColumns="false" DataKeyNames="Department_ID" RowStyle-CssClass="gvtr"  >
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Email" HeaderText="E_mail" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Phone1" HeaderText="Phone" ItemStyle-CssClass="gvtd"/>
                        <asp:TemplateField HeaderText="Hospital" ItemStyle-CssClass="gvtd">
                            <ItemTemplate>
                                <asp:Label ID="lbHospital" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowDoctorText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">Doctors</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowDoctorGrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvDoctor" AutoGenerateColumns="false" DataKeyNames="Doctor_ID" RowStyle-CssClass="gvtr">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Email" HeaderText="E-mail" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Phone1" HeaderText="Phone 1" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Phone2" HeaderText="Phone 2" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Adress" HeaderText="Adress" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="City" HeaderText="City" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Specialisation" HeaderText="Specialisation" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="CV" HeaderText="CV" ItemStyle-CssClass="gvtd"/>
                        <asp:TemplateField HeaderText="Hospitals" ItemStyle-CssClass="gvtdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel1" CssClass="listbox"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowEvaluationText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">Evaluations</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowEvaluationGrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvEvaluation" AutoGenerateColumns="false" DataKeyNames="Evaluation_ID" RowStyle-CssClass="gvtr"  >
                    <Columns>
                        <asp:TemplateField HeaderText="Type" ItemStyle-CssClass="gvtd">
                            <ItemTemplate>
                                <asp:Label ID="lbType" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="gvtd">
                            <ItemTemplate>
                                <asp:Label ID="lbName" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Feedback" HeaderText="Feedback" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Accuracy" HeaderText="Accuracy" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Quality" HeaderText="Quality" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Evaluation_txt" HeaderText="Evaluation" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Label" HeaderText="Label" ItemStyle-CssClass="gvtd"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow ID="rowHospitalText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">Hospitals</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowHospitalGrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvHospital" AutoGenerateColumns="false" DataKeyNames="Hospital_ID" RowStyle-CssClass="gvtr"  >
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Adress" HeaderText="Adress" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="City" HeaderText="City" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Central_number" HeaderText="Central Number" ItemStyle-CssClass="gvtd"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowProjectManagerText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">Project Managers</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowProjectManagerGrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvProjectManager" AutoGenerateColumns="false" DataKeyNames="ProjectManager_ID" RowStyle-CssClass="gvtr"  >
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="CV" HeaderText="CV" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Email" HeaderText="E-mail" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Phone1" HeaderText="Phone 1" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Phone2" HeaderText="Phone 2" ItemStyle-CssClass="gvtd"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowProjectText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">Projects</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowProjectGrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvProject" AutoGenerateColumns="false" DataKeyNames="Project_ID" RowStyle-CssClass="gvtr"  >
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Start_Date" HeaderText="Start Date" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="End_Date" HeaderText="End Date" ItemStyle-CssClass="gvtd"/>
                        <asp:TemplateField HeaderText="CRA's" ItemStyle-CssClass="gvtdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel1" CssClass="listbox"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Doctors" ItemStyle-CssClass="gvtdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel2" CssClass="listbox"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hospitals" ItemStyle-CssClass="gvtdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel3" CssClass="listbox"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Managers" ItemStyle-CssClass="gvtdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel4" CssClass="listbox"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowStudyCoordinatorText" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:Label runat="server">Study Coordinators</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowStudyCoordinatorGrid" CssClass="homeRow">
            <asp:TableCell CssClass="homeCell">
                <asp:GridView runat="server" ID="gvStudyCoordinator" AutoGenerateColumns="false" DataKeyNames="StudyCoordinator_ID" RowStyle-CssClass="gvtr"  >
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="CV" HeaderText="CV" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Email" HeaderText="E-mail" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Phone1" HeaderText="Phone 1" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Phone2" HeaderText="Phone 2" ItemStyle-CssClass="gvtd"/>
                        <asp:BoundField DataField="Specialisation" HeaderText="Specialisation" ItemStyle-CssClass="gvtd"/>
                        <asp:TemplateField HeaderText="Doctors" ItemStyle-CssClass="gvtdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel1" CssClass="listbox"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
</asp:Content>