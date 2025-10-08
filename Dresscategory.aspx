<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Dresscategory.aspx.cs" Inherits="Dresscategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        .card {
            --bg-card: #27272a;
            --primary: #6d28d9;
            --primary-800: #4c1d95;
            --primary-shadow: #2e1065;
            --light: #d9d9d9;
            --zinc-800: #18181b;
            --bg-linear: linear-gradient(0deg, var(--primary) 50%, var(--light) 125%);
            position: relative;
            display: flex;
            flex-direction: column;
            gap: 0.75rem;
            padding: 1rem;
            width: 14rem;
            background-color: var(--bg-card);
            border-radius: 1rem;
        }

        .image_container {
            overflow: hidden;
            cursor: pointer;
            position: relative;
            z-index: 5;
            width: 100%;
            height: 8rem;
            background-color: var(--primary-800);
            border-radius: 0.5rem;
        }

            .image_container .image {
                position: absolute;
                top: 50%;
                left: 50%;
                transform: translate(-50%, -50%);
                width: 3rem;
                fill: var(--light);
            }

        .title {
            overflow: clip;
            width: 100%;
            font-size: 1rem;
            font-weight: 600;
            color: var(--light);
            text-transform: capitalize;
            text-wrap: nowrap;
            text-overflow: ellipsis;
        }

        .size {
            font-size: 0.75rem;
            color: var(--light);
        }

        .list-size {
            display: flex;
            align-items: center;
            gap: 0.25rem;
            margin-top: 0.25rem;
        }

            .list-size .item-list {
                list-style: none;
            }

            .list-size .item-list-button {
                cursor: pointer;
                padding: 0.5rem;
                background-color: var(--zinc-800);
                font-size: 0.75rem;
                color: var(--light);
                border: 2px solid var(--zinc-800);
                border-radius: 0.25rem;
                transition: all 0.3s ease-in-out;
            }

        .item-list-button:hover {
            border: 2px solid var(--light);
        }

        .item-list-button:focus {
            background-color: var(--primary);
            border: 2px solid var(--primary-shadow);
            box-shadow: inset 0px 1px 4px var(--primary-shadow);
        }

        .action {
            display: flex;
            align-items: center;
            gap: 1rem;
        }

        .price {
            font-size: 1.5rem;
            font-weight: 700;
            color: var(--light);
        }

        .cart-button {
            cursor: pointer;
            display: flex;
            justify-content: center;
            align-items: center;
            gap: 0.25rem;
            padding: 0.5rem;
            width: 100%;
            background-image: var(--bg-linear);
            font-size: 0.75rem;
            font-weight: 500;
            color: var(--light);
            text-wrap: nowrap;
            border: 2px solid hsla(262, 83%, 58%, 0.5);
            border-radius: 0.5rem;
            box-shadow: inset 0 0 0.25rem 1px var(--light);
        }

            .cart-button .cart-icon {
                width: 1rem;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid bg-primary hero-header mb-5">
        <div class="container">
            <div class="row g-5 align-items-center">
                <div class="col-lg-6 text-center text-lg-start">
                    <h3 class="fw-light text-white animated slideInRight">Adda</h3>
                    <h1 class="display-4 text-white animated slideInRight">Shoes <span class="fw-light text-dark">Aniket</span> For Brand Shoes</h1>
                    <p class="text-white mb-4 animated slideInRight">
                        Lorem ipsum dolor sit amet, consectetur adipiscing
                        elit. Etiam feugiat rutrum lectus, sed auctor ex malesuada id. Orci varius natoque penatibus et
                        magnis dis parturient montes.
                    </p>
                    <a href="#" class="btn btn-dark py-2 px-4 me-3 animated slideInRight">Shop Now</a>
                    <a href="#" class="btn btn-outline-dark py-2 px-4 animated slideInRight">Contact Us</a>
                </div>
                <div class="col-lg-6">
                    <img class="img-fluid animated pulse infinite" src="Adidas-Climawarm-Running-Shoes-For-Men-1.jpeg" alt="">
                </div>
            </div>
        </div>
    </div>

   <div class="container-fluid py-5">
    <div class="container">
        <div class="mx-auto text-center wow fadeIn" data-wow-delay="0.1s" style="max-width: 600px;">
            <h1 class="text-primary mb-3"><span class="fw-light text-dark">Our Footwear</span> Shoes Products</h1>
            <p class="mb-5">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis aliquet, erat non malesuada consequat, nibh erat tempus risus.</p>
        </div>
        <div class="row">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-6 col-lg-3 wow fadeIn" data-wow-delay="0.1s">
                        <div class="product-item text-center border h-100 p-4">
                            <img src='<%# Eval("Image", "/Admin/Uploadproimg/{0}") %>' alt="Image" class="img-fluid mb-4" />
                            <div class="mb-2">
                                <small class="fa fa-star text-primary"></small>
                                <small class="fa fa-star text-primary"></small>
                                <small class="fa fa-star text-primary"></small>
                                <small class="fa fa-star text-primary"></small>
                                <small class="fa fa-star text-primary"></small>
                                <small style="color:chartreuse;">(99)</small>
                            </div>
                            <h1 style="color: blue;"><p style="font-size:20px; color:red;">Category Name:</p><%# Eval("Category") %></h1>
                            <p>Brand Name:</p><p style="color: red;"><%# Eval("BrandName") %></p>
                            <a href="#" class="h6 d-inline-block mb-2"><%# Eval("ProductName") %></a>
                            <h5 class="text-primary mb-3">Rs.<%# Eval("Price") %></h5>
                           <%-- <a href="#" class="btn btn-outline-primary px-3">Add To Cart</a>--%>
                           <asp:Button ID="btnAddToCart" class="btn btn-outline-primary px-3" runat="server" Text="Add to cart" CommandName="AddToCart" CommandArgument='<%# Eval("Id") %>' BorderStyle="None" />
                           
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
    


</asp:Content>
