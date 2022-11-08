USE InterStoreTransferSystem

SELECT * FROM ZipCodes

SELECT * FROM Stores

SELECT ItemId, Quantity, Stores.StoreId
FROM Stores
	JOIN StoreItems ON Stores.StoreId = StoreItems.StoreId

SELECT * FROM Items

SELECT * FROM Transfers