var React = require('react');
var Action = require('./../actions/GroceryItemActionCreator.js');

module.exports = React.createClass({
    delete: function (e) {
        // prevent the page from refrashing 
        e.preventDefault();
        Action.delete(this.props.item);
    },
    togglePurchased: function(e){
        e.preventDefault();
        if(this.props.item.purchased){
            Action.unbuy(this.props.item);
        }
        else {
            Action.buy(this.props.item);
        }
    },
    render: function () {
        return (
            <div className="grocery-item row">
                <div className="six columns">
                    <h4 className={this.props.item.purchased ? "strikethrough" : ""}>
                        {this.props.item.name}
                    </h4>
                </div>
                <form className="three colums" onSubmit={this.togglePurchased}>
                    <button className={this.props.item.purchased ? "" : "button-primary"}>
                        {this.props.item.purchased ? "Unbuy" : "Buy"}
                    </button>
                </form>
                <form className="three colums" onSubmit={this.delete}>
                    <button>&times;</button></form>
            </div>
        )
    }
})