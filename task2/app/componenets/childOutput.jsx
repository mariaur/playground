var React = require('react');

module.exports = React.createClass({
    render() {
        return (
            <div>
                  <h4 className='text'>
                   {this.props.input}
                </h4>
            </div>
        )
    }
});