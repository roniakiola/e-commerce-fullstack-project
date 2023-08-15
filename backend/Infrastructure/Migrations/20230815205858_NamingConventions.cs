using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NamingConventions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Products_ProductId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContactDetails_Users_UserId",
                table: "UserContactDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserContactDetails",
                table: "UserContactDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "carts");

            migrationBuilder.RenameTable(
                name: "UserContactDetails",
                newName: "user_contact_details");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "order_item");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "cart_item");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "users",
                newName: "modified_at");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "users",
                newName: "ix_users_email");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "products",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "products",
                newName: "images");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DescriptionLong",
                table: "products",
                newName: "description_long");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "products",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "products",
                newName: "ix_products_category_id");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "orders",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "orders",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "orders",
                newName: "modified_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "orders",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "orders",
                newName: "ix_orders_user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "carts",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "carts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "carts",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "carts",
                newName: "modified_at");

            migrationBuilder.RenameColumn(
                name: "ExpiresAt",
                table: "carts",
                newName: "expires_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "carts",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                table: "carts",
                newName: "ix_carts_user_id");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "user_contact_details",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "user_contact_details",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "user_contact_details",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_contact_details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_contact_details",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "user_contact_details",
                newName: "postal_code");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "user_contact_details",
                newName: "phone_number");

            migrationBuilder.RenameIndex(
                name: "IX_UserContactDetails_UserId",
                table: "user_contact_details",
                newName: "ix_user_contact_details_user_id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "order_item",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "order_item",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "order_item",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "order_item",
                newName: "order_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductId",
                table: "order_item",
                newName: "ix_order_item_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "order_item",
                newName: "ix_order_item_order_id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "cart_item",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cart_item",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "cart_item",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "cart_item",
                newName: "cart_id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductId",
                table: "cart_item",
                newName: "ix_cart_item_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartId",
                table: "cart_item",
                newName: "ix_cart_item_cart_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_products",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_categories",
                table: "categories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_carts",
                table: "carts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_contact_details",
                table: "user_contact_details",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_item",
                table: "order_item",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cart_item",
                table: "cart_item",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_cart_item_carts_cart_id",
                table: "cart_item",
                column: "cart_id",
                principalTable: "carts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_cart_item_products_product_id",
                table: "cart_item",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_carts_users_user_id",
                table: "carts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_item_orders_order_id",
                table: "order_item",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_item_products_product_id",
                table: "order_item",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_users_user_id",
                table: "orders",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_contact_details_users_user_id",
                table: "user_contact_details",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cart_item_carts_cart_id",
                table: "cart_item");

            migrationBuilder.DropForeignKey(
                name: "fk_cart_item_products_product_id",
                table: "cart_item");

            migrationBuilder.DropForeignKey(
                name: "fk_carts_users_user_id",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "fk_order_item_orders_order_id",
                table: "order_item");

            migrationBuilder.DropForeignKey(
                name: "fk_order_item_products_product_id",
                table: "order_item");

            migrationBuilder.DropForeignKey(
                name: "fk_orders_users_user_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "fk_products_categories_category_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "fk_user_contact_details_users_user_id",
                table: "user_contact_details");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "pk_carts",
                table: "carts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_contact_details",
                table: "user_contact_details");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_item",
                table: "order_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cart_item",
                table: "cart_item");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "carts",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "user_contact_details",
                newName: "UserContactDetails");

            migrationBuilder.RenameTable(
                name: "order_item",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "cart_item",
                newName: "CartItem");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_at",
                table: "Users",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_users_email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "images",
                table: "Products",
                newName: "Images");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description_long",
                table: "Products",
                newName: "DescriptionLong");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "ix_products_category_id",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "Orders",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "modified_at",
                table: "Orders",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Orders",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_orders_user_id",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "Carts",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Carts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Carts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "modified_at",
                table: "Carts",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "expires_at",
                table: "Carts",
                newName: "ExpiresAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Carts",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_carts_user_id",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "UserContactDetails",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "UserContactDetails",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "UserContactDetails",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserContactDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserContactDetails",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "postal_code",
                table: "UserContactDetails",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "UserContactDetails",
                newName: "PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "ix_user_contact_details_user_id",
                table: "UserContactDetails",
                newName: "IX_UserContactDetails_UserId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderItem",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrderItem",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "OrderItem",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "OrderItem",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "ix_order_item_product_id",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "ix_order_item_order_id",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "CartItem",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CartItem",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "CartItem",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "cart_id",
                table: "CartItem",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "ix_cart_item_product_id",
                table: "CartItem",
                newName: "IX_CartItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "ix_cart_item_cart_id",
                table: "CartItem",
                newName: "IX_CartItem_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserContactDetails",
                table: "UserContactDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Products_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserContactDetails_Users_UserId",
                table: "UserContactDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
