var React = require('react');
var Action = require('./../actions/textUpdater.js');

module.exports = React.createClass({
    getInitialState() {
        return { input: "" };
    },
    handleInputName(e) {
        this.setState({ input: e.target.value });
    },
    updateItem(e) {
        e.preventDefault();
        Action.update({
            name: this.state.input
        });
        this.setState({
            input: ''
        })
    },
    render() {
        var buttonStyle = {
            fontWeight: 600,
            textTransform: 'uppercase',
            marginBottom: '50px',
            backgroundColor: '1219ea',
            color: 'ffffff'
        };

        return (
            <form onSubmit={this.updateItem}>
                <input value={this.state.input} onChange={this.handleInputName} />
                <div className="row">
                    <div className="row">
                        <button style={buttonStyle}> Update </button>
                    </div>
                </div>
            </form>
        )
    }
})