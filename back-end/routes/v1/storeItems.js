const { wrap } = require("../../utils/request");
const sql = require("mssql/msnodesqlv8");

module.exports = wrap(async function (req, res) {
  const storeId = req.query.storeId;
  const pool = new sql.ConnectionPool(require("../../sqlConfig.json"));
  await pool.connect();
  const request = new sql.Request(pool);
  const query = `SELECT * FROM StoreItems WHERE ItemId = ${req.params.itemId} AND StoreId != ${storeId}`;
  const result = await request.query(query);
  pool.close();

  return res.status(200).json({ status: 200, data: result.recordset });
});
