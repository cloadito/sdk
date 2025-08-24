namespace Cloudito.Sdk;

internal partial class UrlsConst
{
    public class Shop
    {
        public static readonly Func<Guid, string> Delete = (id) => $"{V1BaseUrl}/shop/delete?id={id}";

        public static readonly Func<Guid, string> GetAdmins = (id) => $"{V1BaseUrl}/shop/get-admins?id={id}";

        public static readonly Func<int, int, string?, string> GetShopsList = (page, count, q) =>
            $"{V1BaseUrl}/shop/get-list?page={page}&count={count}{(string.IsNullOrEmpty(q) ? "" : $"&q={q}")}";

        public static readonly Func<Guid, int, int, string> GetUserShops = (id, page, count) =>
            $"{V1BaseUrl}/shop/get-user-shops?id={id}&page={page}&count={count}";

        /// <summary>
        /// Remove admin first parameter is shop id and second is user id
        /// </summary>
        public static readonly Func<Guid, Guid, string> RemoveAdmin = (shopId, userId) =>
            $"{V1BaseUrl}/shop/remove-admin?shopId={shopId}&userId={userId}";

        public const string Upsert = $"{V1BaseUrl}/shop/upsert";

        public const string UpsertAdmin = $"{V1BaseUrl}/shop/upsert-admin";

        public class Product
        {
            public const string AddProductToShop = $"{V1BaseUrl}/product/add-product-to-shop";

            public static readonly Func<Guid, string> Delete = (id) => $"{V1BaseUrl}/product/delete?id={id}";

            public static readonly Func<Guid, string> DeleteProperty =
                (id) => $"{V1BaseUrl}/product/delete-property?id={id}";

            /// <summary>
            /// Remove product from shop first parameter is product id and second is shop id
            /// </summary>
            public static readonly Func<Guid, Guid, string> DeleteShopProduct =
                (productId, shopId) => $"{V1BaseUrl}/product/delete-shop-product?shopId={shopId}&productId={productId}";

            public static readonly Func<Guid, string> GetDetails = (id) => $"{V1BaseUrl}/product/get-details?id={id}";

            public const string GetList = $"{V1BaseUrl}/product/get-list";

            public static readonly Func<Guid, string> GetProperties = (categoryId) =>
                $"{V1BaseUrl}/product/get-properties?categoryId={categoryId}";

            public static readonly Func<Guid, string> GetSellers = (id) => $"{V1BaseUrl}/product/get-sellers?id={id}";

            public const string Upsert = $"{V1BaseUrl}/product/upsert";

            public const string UpsertProperty = $"{V1BaseUrl}/product/upsert-property";
        }

        public class Category
        {
            public const string AddCategoryToShop = $"{V1BaseUrl}/category/add-category-to-shop";
            
            public static readonly Func<Guid,string> Delete = (id)=> $"{V1BaseUrl}/category/delete?id={id}";
            
            public const string GetList = $"{V1BaseUrl}/category/get-list";
            
            public static readonly Func<Guid,string> GetShopCategories = (shopId)=> $"{V1BaseUrl}/category/get-shop-categories?shopId={shopId}";
            
            public static readonly Func<Guid,Guid,string> DeleteShopCategory = (shopId,categoryId)=> $"{V1BaseUrl}/category/delete-shop-category?shopId={shopId}&categoryId={categoryId}";

            public const string Upsert = $"{V1BaseUrl}/category/upsert";
        }
    }
}