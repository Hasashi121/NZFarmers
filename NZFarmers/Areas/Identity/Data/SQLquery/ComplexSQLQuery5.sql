SELECT 
    nzu.Email,
    COUNT(sci.ShoppingCartItemID) as ItemsInCart,
    SUM(fp.Price * sci.Quantity) as CartTotal
FROM ShoppingCartItems sci
INNER JOIN AspNetUsers nzu ON sci.UserID = nzu.Id
INNER JOIN FarmerProducts fp ON sci.FarmerProductID = fp.FarmerProductID
GROUP BY nzu.Id, nzu.Email;