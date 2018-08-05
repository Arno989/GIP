<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.0.Master" AutoEventWireup="true" CodeBehind="Testpage.aspx.cs" Inherits="Presentation.Testpage" %>
<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <title>Administrator page</title>
</asp:Content>

<asp:Content ID="Form" ContentPlaceHolderID="Form" runat="server">
    <div style="padding-left:300px">
    <div class="view-page">
    <div class="form">
        <h2>Account management</h2>
        <hr />
        <div class="gridview">
            <asp:GridView ID="Gridview" runat="server" AllowSorting="True" OnSorting="Sort" onrowdatabound="Gridview_RowDataBound" AutoGenerateColumns="False" DataKeyNames="User_ID" CssClass="gv" OnSelectedIndexChanged="Gridview_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton id="myBtn" runat="server" autopostback="true" ToolTip="Edit record"><i class="material-icons">edit</i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"/>
                    <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email"/>
                    <asp:BoundField DataField="Type" HeaderText="Account type" SortExpression="Type"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>
        

 <!-- Trigger/Open The Modal -->
    </div> 
<!-- The Modal -->
<div id="myModal" class="modal">

  <!-- Modal content -->
  <div class="modal-content">
    <span class="close">&times;</span>
    <p>Some text in the Modal..</p>
  </div>

</div> 


    <script>
    // Get the modal
var modal = document.getElementById('myModal');

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on the button, open the modal
btn.onclick = function() {
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

        </script>
</asp:Content>
