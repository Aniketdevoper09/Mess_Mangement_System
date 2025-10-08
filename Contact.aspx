<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .bod {
            background: rgb(34,193,195);
            background: linear-gradient(0deg, rgba(34,193,195,1) 0%, rgba(253,45,95,0.7288165266106443) 100%);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div class="bg-light py-3">
      <div class="container">
        <div class="row">
          <div class="col-md-12 mb-0"><a href="index.html">Home</a> <span class="mx-2 mb-0">/</span> <strong class="text-black">Contact</strong></div>
        </div>
      </div>
    </div>
    <div class="site-section">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <h2 class="h3 mb-3 text-black">Get In Touch</h2>
          </div>
          <div class="col-md-7">

            <div action="#" method="post">
              
              <div class="p-3 p-lg-5 border">
                <div class="form-group row">
                  <div class="col-md-6">
                    <label for="c_fname" class="text-black"> Full Name <span class="text-danger">*</span></label>
                    <%--<input type="text" class="form-control" id="c_fname" name="c_fname">--%>
                    <asp:TextBox ID="TextBox1" runat="server"  class="form-control"></asp:TextBox>
                  </div>
                  <div class="col-md-6">
                    <label for="c_lname" class="text-black">Mobile<span class="text-danger">*</span></label>
                    <%--<input type="text" class="form-control" id="c_lname" name="c_lname">--%>
                        <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                  </div>
                </div>
                <div class="form-group row">
                  <div class="col-md-12">
                    <label for="c_email" class="text-black">Email <span class="text-danger">*</span></label>
                    <%--<input type="email" class="form-control" id="c_email" name="c_email" placeholder="">--%>
                            <asp:TextBox ID="TextBox3" type="email" runat="server" class="form-control"></asp:TextBox>
                  </div>
                </div>
                <div class="form-group row">
                  <div class="col-md-12">
                    <label for="c_message" class="text-black">Message </label>
                    <%--<textarea name="c_message" id="c_message" cols="30" rows="7" class="form-control"></textarea>--%>
                    <asp:TextBox ID="TextBox4" runat="server" cols="30" rows="7" class="form-control"></asp:TextBox>
                  </div>
                </div>
                <div class="form-group row">
                  <div class="col-lg-12">
                   <%-- <input type="submit" class="btn btn-primary btn-lg btn-block" value="Send Message">--%>
                        <asp:Button ID="Button1" runat="server" Text="Send Message" class="btn btn-primary btn-lg btn-block" OnClick="Button1_Click" />
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-md-5 ml-auto">
            <div class="p-4 border mb-3">
              <span class="d-block text-primary h6 text-uppercase">New York</span>
              <p class="mb-0">203 Fake St. Mountain View, San Francisco, California, USA</p>
            </div>
            <div class="p-4 border mb-3">
              <span class="d-block text-primary h6 text-uppercase">London</span>
              <p class="mb-0">203 Fake St. Mountain View, San Francisco, California, USA</p>
            </div>
            <div class="p-4 border mb-3">
              <span class="d-block text-primary h6 text-uppercase">Canada</span>
              <p class="mb-0">203 Fake St. Mountain View, San Francisco, California, USA</p>
            </div>

          </div>
        </div>
      </div>
    </div>
</asp:Content>

