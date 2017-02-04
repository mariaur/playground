var React = require('react');
var Action = require('./../actions/GroceryItemActionCreator.js');

module.exports =  React.createClass({
    getInitialState(){
        return {input:""};
    },
    handleInputName(e){
        this.setState({input:e.target.value});
    },
    addItem(e){
        e.preventDefault();
        Action.add({
            name:this.state.input
        });
        this.setState({
            input:''
        })
    },

    render() {
        return (
            <div className='grocery-addItem'>
                <form onSubmit={this.addItem}>
                    <input value={this.state.input} onChange={this.handleInputName}/>
                    <button> Add Item </button>
                </form>
            </div>
        )
    }
});
