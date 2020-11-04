<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShaneSampleApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">    
	    <div class="card">		        
            <h3 class="card-header text-center font-weight-bold text-uppercase py-4">Patients List</h3>
            <div class="card-body">                                
                <div class="table-editable">
                    <span class="table-add float-right mb-3 mr-2">                        
                        <asp:LinkButton class="text-success" ID="AddNewRecord" OnClick="AddNewRecord_Click" runat="server" Text="">
                            <i class="fa fa-plus fa-2x" aria-hidden="true"></i>
                        </asp:LinkButton>
                    </span>

                    
                <asp:Table ID="PatientsTable" CssClass="table table-bordered table-responsive-md table-striped text-center" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell Scope="Column" Text="First Name"/>
                        <asp:TableHeaderCell Scope="Column" Text="Last Name"/>
                        <asp:TableHeaderCell Scope="Column" Text="Gender"/>
                        <asp:TableHeaderCell Scope="Column" Text="Email"/>
                        <asp:TableHeaderCell Scope="Column" Text="Phone Number"/>
                        <asp:TableHeaderCell Scope="Column" Text="Notes"/>
                        <asp:TableHeaderCell Scope="Column" Text="Edit"/>
                        <asp:TableHeaderCell Scope="Column" Text="Delete"/>
                    </asp:TableHeaderRow>
                    
                </asp:Table>
            </div>            
        </div>	
</div>



    
</asp:Content>