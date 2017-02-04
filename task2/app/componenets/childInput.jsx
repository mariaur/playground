var React = require('react');
var Action = require('./../actions/textUpdater.js');

module.exports = React.createClass({
    getInitialState(){
        return {input:""};
    },
    handleInputName(e){
        this.setState({input:e.target.value});
    },
    updateItem(e){
        e.preventDefault();
        Action.update({
            name:this.state.input
        });
        this.setState({
            input:''
        })
    },
    render() {
        return (
           <div className='child-input'>
                <form onSubmit={this.updateItem}>
                    <input value={this.state.input} onChange={this.handleInputName}/>
                    <button> Update </button>
                </form>
            </div>
        )
    }
});