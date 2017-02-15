module.exports = function (app){
        console.log('in items on server');

var items = [{
        name: "Ice Cream"
    }, {
        name: "Waffles"
    }, {
        name: "Candy",
        purchased: true
    }, {
        name: "Waffles"
    }];

    app.route('/api/items')
    .get(function(req,res){
        console.log(`${req.body} req voby in get`);
        console.log(`${res.body} res voby in get`);
        res.send(items);
    })
    .post(function(req,res){
        console.log(`${req} req voby post`);
        console.log(`${res} res voby post`);
        var item = req.body;
        items.push(item);
    })
}