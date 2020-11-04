<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOrEditPatient.aspx.cs" Inherits="ShaneSampleApp.AddOrEditPatient" %>

<asp:Content ID="AddOrEditPatientContent" ContentPlaceHolderID="BodyContent" runat="server">            
    <div class="container">        
            <div class="box-header">                
                <div class="col-md-6">
                    <h2 runat="server" id="registerOrEdit"></h2>
                    <hr>
                </div>
            </div>            
            <div class="box-body col-md-6">
                <asp:HiddenField runat="server" id="patientIdField"  />
                <asp:HiddenField runat="server" id="createdDate"  />
                <asp:HiddenField runat="server" id="lastUpdatedDate"  />
                           
                <div class="form-group">            
                    <asp:Label runat="server" ID="lblFirstName" Text="First Name" AssociatedControlID="firstName"></asp:Label>
                    <asp:TextBox runat="server" ID="firstName" placeholder="John"></asp:TextBox>
            
                    <asp:RequiredFieldValidator 
                        ID="firstNameFieldValidator" 
                        runat="server" 
                        ControlToValidate="firstName" 
                        CssClass="field-validation-error" 
                        ErrorMessage="First name is required." />                    
                </div>
        
                <div class="form-group">
                    <asp:Label runat="server" ID="lblLastName" Text="Last Name" AssociatedControlID="lastName"></asp:Label>
                    <asp:TextBox runat="server" ID="lastName" placeholder="Doe"></asp:TextBox>            
                    <asp:RequiredFieldValidator 
                        ID="lastNameFieldValidator" 
                        runat="server" 
                        ControlToValidate="lastName" 
                        CssClass="field-validation-error" 
                        ErrorMessage="Last name is required." />                    
                </div>
        
                <div class="form-group">
                    <asp:Label runat="server" ID="lblPhone" Text="Phone Number" AssociatedControlID="phone"></asp:Label>            
                    <asp:TextBox runat="server" ID="phone" placeholder="(xxx) xxx-xxxx"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="phoneFieldValidator" 
                        runat="server" 
                        ControlToValidate="phone" 
                        CssClass="field-validation-error" 
                        ErrorMessage="Phone number is required." />      
                    <asp:RegularExpressionValidator 
                        ID="phoneFormatValidation" 
                        runat="server" 
                        ErrorMessage="Phone number format is xxx-xxx-xxxx"
                        CssClass="field-validation-error" 
                        ControlToValidate="phone"
                        ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"
                        />                                
                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblemail" Text="Email Address" AssociatedControlID="email"></asp:Label>           
                    <asp:TextBox runat="server" ID="email" placeholder="johndoe@gmail.com"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="emailRequiredValidator" 
                        runat="server" 
                        ControlToValidate="email" 
                        CssClass="field-validation-error" 
                        ErrorMessage="Email is required." />      
                    <asp:RegularExpressionValidator 
                        ID="emailFormatValidator" 
                        runat="server" 
                        ErrorMessage="Not a valid Email address."
                        CssClass="field-validation-error" 
                        ControlToValidate="email"
                        ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"
                        />
                </div>        
                <div class="form-group">                
                    <asp:Label runat="server" ID="genderLabel" Text="Gender" AssociatedControlID="gender"></asp:Label>            
                    <asp:DropDownList ID="gender" runat="server">
                        <asp:ListItem Value="UNSPECIFIED" Text="Unspecified"  Selected="True"/>
                        <asp:ListItem Value="MALE" Text="Male"/> 
                        <asp:ListItem Value="FEMALE" Text="Female"/>                
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" ID="notesLabel" Text="Notes" AssociatedControlID="notes"></asp:Label>            
                    <asp:TextBox runat="server" ID="notes" CssClass="form-control input-lg" placeholder="Notes" TextMode="MultiLine"></asp:TextBox>
                </div>

                <div class="form-group">                    
                    <asp:Button runat="server" CssClass="btn btn-primary" ID="submit" Text="Submit" OnClick="submit_Click" ValidateRequestMode="Inherit" />            
                    <asp:Button runat="server" CssClass="btn btn-secondary" ID="cancel" Text="Cancel" PostBackUrl="~/Default.aspx" CausesValidation="false" />                                
                </div>            
            </div>                
    </div>
</asp:Content>
    
    