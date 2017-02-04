var React = require('react');

module.exports = class GroceryItem extends React.Component {
    render() {
        return (
            <div>
                <h4 className={this.props.item.purchased ? "strikethrough" : ""}>
                    {this.props.item.name}
                </h4>
            </div>
        )
    }
}