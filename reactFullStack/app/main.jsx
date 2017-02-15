var GroceryItemList = require('./componenets/GroceryItemList.jsx');
var React = require('react');
var ReactDOM = require('react-dom');
var GroceryItemStore = require('./stores/GroceryItemStore.jsx');

var initial = GroceryItemStore.getItems();

function render() {
    ReactDOM.render(
        <GroceryItemList items={initial} />,
        document.getElementById('app')
    );
}

GroceryItemStore.onChange(function (items) {
    initial = items;
    render();
});

render();
