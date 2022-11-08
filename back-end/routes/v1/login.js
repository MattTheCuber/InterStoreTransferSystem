const { wrap } = require("../../utils/request");

module.exports = wrap(async function (req, res) {
  // If the authorization has passed this far, the user is authorized
  return res.status(200).json({ status: 200, data: "Success" });
});
