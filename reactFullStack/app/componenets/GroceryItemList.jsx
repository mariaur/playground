var React = require('react');
var Item = require('./GroceryItem.jsx');
var AddItem = require('./GroceryListAddItem.jsx');

module.exports = class GroceryItemList extends React.Component {
    render() {
        return (
            <div>
                <h1>Grocery Listify </h1>
                <div>
                    {this.props.items.map(function (item, index) {
                        return (
                            <Item item={item} key={"item" + index} />
                        )
                    })
                    }
                </div>
            <AddItem />
            </div>
        )
    }
}