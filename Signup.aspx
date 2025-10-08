<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Signup Form</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <style>
        /* Basic styling for the form container */
        .form-container {
            max-width: 600px;
            margin: 50px auto; /* Center the form horizontally with 50px top margin */
            padding: 20px;
            border: 2px solid red;
            border-radius: 20px;
            background: rgb(238,174,202);
            background: radial-gradient(circle, rgba(238,174,202,1) 0%, rgba(148,187,233,1) 100%);
        }

        /* Basic styling for the form */
        .signup-form {
            width: 100%;
        }

        /* Style for form fields */
        .form-group {
            margin-bottom: 20px;
        }

            .form-group label {
                display: block;
                font-weight: bold;
            }

            .form-group input[type="text"],
            .form-group input[type="email"],
            .form-group input[type="password"],
            .form-group select {
                width: 100%;
                padding: 10px;
                border: 1px solid #ccc;
                border-radius: 5px;
                box-sizing: border-box; /* Ensure padding is included in width */
            }

            /* Style for file upload */
            .form-group input[type="file"] {
                margin-top: 5px;
            }

        /* Style for submit button */
        .btn-submit {
            display: inline-block;
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
        }

            .btn-submit:hover {
                background-color: #45a049;
            }

        body {
            background: rgb(63,94,251);
            background: radial-gradient(circle, rgba(63,94,251,1) 0%, rgba(252,70,107,1) 100%);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="form-container">
        <div   class="signup-form">
            <div class="form-group">
                <label for="txtUsername">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtConfirmPassword">Confirm Password:</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
           
            <div class="form-group">
                <label for="fileProfilePic">Profile Picture:</label>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Sign Up" OnClick="btnSubmit_Click" CssClass="btn-submit" />
            <p style="padding-left: 150px;">Already have an account?<a href="Login.aspx" style="text-decoration: none; color: darkred;">Login</a></p>
        </div>
    </div>
</asp:Content>

