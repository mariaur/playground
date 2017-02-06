var React = require('react');

module.exports = React.createClass({
    render() {
        var textStyle = {
            color: 'ffffff'
        };

        return (
            <h4 style={textStyle}>
                {this.props.input}
            </h4>
        )
    }
});