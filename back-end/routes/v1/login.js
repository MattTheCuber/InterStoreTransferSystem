const { wrap } = require("../../utils/request");

module.exports = wrap(async function (req, res) {
  return res.status(200).json({ status: 200, data: "Success" });
});
