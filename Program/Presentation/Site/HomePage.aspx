<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Presentation.Site.HomeSite" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
	<title>Home</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div class="home-page">
    <div class="form">
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

        <hr />

        <asp:Table ID="resultTable" runat="server" Visible="false" CssClass="resultTable">

        <asp:TableRow ID="rowCRAText" CssClass="textRow">
            <asp:TableCell>
                <h3>CRA's</h3>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowCRAGrid" CssClass="gvRow">
            <asp:TableCell>
                <asp:GridView runat="server" ID="gvCRA" AutoGenerateColumns="false" DataKeyNames="CRA_ID" CssClass="gv">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name"/>
                        <asp:BoundField DataField="CV" HeaderText="CV"/>
                        <asp:BoundField DataField="Email" HeaderText="E-mail"/>
                        <asp:BoundField DataField="Phone1" HeaderText="Phone 1"/>
                        <asp:BoundField DataField="Phone2" HeaderText="Phone 2"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowClientText" CssClass="textRow">
            <asp:TableCell>
                <h3>Clients</h3>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowClientGrid" CssClass="gvRow">
            <asp:TableCell>
                <asp:GridView runat="server" ID="gvClient" AutoGenerateColumns="false" DataKeyNames="Client_ID" CssClass="gv">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name"/>
                        <asp:BoundField DataField="Adress" HeaderText="Adress"/>
                        <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code"/>
                        <asp:BoundField DataField="City" HeaderText="City"/>
                        <asp:BoundField DataField="Country" HeaderText="Country"/>
                        <asp:BoundField DataField="Contact_Person" HeaderText="Contact Person"/>
                        <asp:BoundField DataField="Invoice_Info" HeaderText="Invoice Info"/>
                        <asp:BoundField DataField="Kind_of_Client" HeaderText="Kind of Client"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowContractText" CssClass="textRow">
            <asp:TableCell>
                <h3>Client Contracts</h3>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowContractGrid" CssClass="gvRow">
            <asp:TableCell>
                <asp:GridView runat="server" ID="gvContract" AutoGenerateColumns="false" DataKeyNames="Contract_ID" CssClass="gv">
                    <Columns>
                        <asp:BoundField DataField="Legal_country" HeaderText="Legal Country"/>
                        <asp:BoundField DataField="Fee" HeaderText="Fee"/>
                        <asp:BoundField DataField="Start_Date" HeaderText="Start Date"/>
                        <asp:BoundField DataField="End_Date" HeaderText="End Date"/>
                        <asp:TemplateField HeaderText="Project">
                            <ItemTemplate>
                                <asp:Label ID="lbProject" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client">
                            <ItemTemplate>
                                <asp:Label ID="lbClient" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowDepartmentText" CssClass="textRow">
            <asp:TableCell>
                <h3>Departments</h3>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowDepartmentGrid" CssClass="gvRow">
            <asp:TableCell>
                <asp:GridView runat="server" ID="gvDepartment" AutoGenerateColumns="false" DataKeyNames="Department_ID" CssClass="gv">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name"/>
                        <asp:BoundField DataField="Email" HeaderText="E_mail"/>
                        <asp:BoundField DataField="Phone1" HeaderText="Phone"/>
                        <asp:TemplateField HeaderText="Hospital">
                            <ItemTemplate>
                                <asp:Label ID="lbHospital" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowDoctorText" CssClass="textRow">
            <asp:TableCell>
                <h3>Doctors</h3>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowDoctorGrid" CssClass="gvRow">
            <asp:TableCell>
                <asp:GridView runat="server" ID="gvDoctor" AutoGenerateColumns="false" DataKeyNames="Doctor_ID" CssClass="gv">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name"/>
                        <asp:BoundField DataField="Email" HeaderText="E-mail"/>
                        <asp:BoundField DataField="Phone1" HeaderText="Phone 1"/>
                        <asp:BoundField DataField="Phone2" HeaderText="Phone 2"/>
                        <asp:BoundField DataField="Adress" HeaderText="Adress"/>
                        <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code"/>
                        <asp:BoundField DataField="City" HeaderText="City"/>
                        <asp:BoundField DataField="Country" HeaderText="Country"/>
                        <asp:BoundField DataField="Specialisation" HeaderText="Specialisation"/>
                        <asp:BoundField DataField="CV" HeaderText="CV"/>
                        <asp:TemplateField HeaderText="Hospitals" ItemStyle-CssClass="tdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel1" CssClass="lb"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowEvaluationText" CssClass="textRow">
            <asp:TableCell>
                <h3>Evaluations</h3>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowEvaluationGrid" CssClass="gvRow">
            <asp:TableCell>
                <asp:GridView runat="server" ID="gvEvaluation" AutoGenerateColumns="false" DataKeyNames="Evaluation_ID" CssClass="gv">
                    <Columns>
                        <asp:TemplateField HeaderText="Type">
                            <ItemTemplate>
                                <asp:Label ID="lbType" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lbName" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Date" HeaderText="Date"/>
                        <asp:BoundField DataField="Feedback" HeaderText="Feedback"/>
                        <asp:BoundField DataField="Accuracy" HeaderText="Accuracy"/>
                        <asp:BoundField DataField="Quality" HeaderText="Quality"/>
                        <asp:BoundField DataField="Evaluation_txt" HeaderText="Evaluation"/>
                        <asp:BoundField DataField="Label" HeaderText="Label"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow ID="rowHospitalText" CssClass="textRow">
            <asp:TableCell>
                <h3>Hospitals</h3>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowHospitalGrid" CssClass="gvRow">
            <asp:TableCell>
                <asp:GridView runat="server" ID="gvHospital" AutoGenerateColumns="false" DataKeyNames="Hospital_ID" CssClass="gv"  >
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name"/>
                        <asp:BoundField DataField="Adress" HeaderText="Adress"/>
                        <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code"/>
                        <asp:BoundField DataField="City" HeaderText="City"/>
                        <asp:BoundField DataField="Country" HeaderText="Country"/>
                        <asp:BoundField DataField="Central_number" HeaderText="Central Number"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowProjectManagerText" CssClass="textRow">
            <asp:TableCell>
                <h3>Project Managers</h3>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowProjectManagerGrid" CssClass="gvRow">
            <asp:TableCell>
                <asp:GridView runat="server" ID="gvProjectManager" AutoGenerateColumns="false" DataKeyNames="ProjectManager_ID" CssClass="gv"  >
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name"/>
                        <asp:BoundField DataField="CV" HeaderText="CV"/>
                        <asp:BoundField DataField="Email" HeaderText="E-mail"/>
                        <asp:BoundField DataField="Phone1" HeaderText="Phone 1"/>
                        <asp:BoundField DataField="Phone2" HeaderText="Phone 2"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowProjectText" CssClass="textRow">
            <asp:TableCell>
                <h3>Projects</h3>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowProjectGrid" CssClass="gvRow">
            <asp:TableCell>
                <asp:GridView runat="server" ID="gvProject" AutoGenerateColumns="false" DataKeyNames="Project_ID" CssClass="gv"  >
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title"/>
                        <asp:BoundField DataField="Start_Date" HeaderText="Start Date"/>
                        <asp:BoundField DataField="End_Date" HeaderText="End Date"/>
                        <asp:TemplateField HeaderText="CRA's" ItemStyle-CssClass="tdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel1" CssClass="lb"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Doctors" ItemStyle-CssClass="tdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel2" CssClass="lb"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hospitals" ItemStyle-CssClass="tdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel3" CssClass="lb"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Managers" ItemStyle-CssClass="tdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel4" CssClass="lb"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="rowStudyCoordinatorText" CssClass="textRow">
            <asp:TableCell>
                <h3>Study Coordinators</h3>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowStudyCoordinatorGrid" CssClass="gvRow">
            <asp:TableCell>
                <asp:GridView runat="server" ID="gvStudyCoordinator" AutoGenerateColumns="false" DataKeyNames="StudyCoordinator_ID" CssClass="gv"  >
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name"/>
                        <asp:BoundField DataField="CV" HeaderText="CV"/>
                        <asp:BoundField DataField="Email" HeaderText="E-mail"/>
                        <asp:BoundField DataField="Phone1" HeaderText="Phone 1"/>
                        <asp:BoundField DataField="Phone2" HeaderText="Phone 2"/>
                        <asp:BoundField DataField="Specialisation" HeaderText="Specialisation"/>
                        <asp:TemplateField HeaderText="Doctors" ItemStyle-CssClass="tdlb">
                            <ItemTemplate>
                                <asp:ListBox runat="server" ID="lbRel1" CssClass="lb"></asp:ListBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
        
    </div>
    </div>
</asp:Content>