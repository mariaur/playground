var React = require('react');
var ReactDOM = require('react-dom');
var Parent = require('./componenets/parent.jsx');
var Store = require('./stores/Store.jsx');

var _input;

function render() {
    ReactDOM.render(
        <Parent  text= {_input}/>,
        document.getElementById('app')
    );
}

Store.onChange(function (text) {
    _input=text;
    render();
});

render();
