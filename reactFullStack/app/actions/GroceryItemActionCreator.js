var dispatcher = require('./../dispatcher.js');

module.exports = {
    add:function(item){
        dispatcher.dispatch({
            payload:item,
            type:"grocery-item:add"
        })
    },
    buy:function(item){
        dispatcher.dispatch({
            payload:item,
            type:"grocery-item:buy"
        })
    },
    unbuy:function(item){
        dispatcher.dispatch({
            payload:item,
            type:"grocery-item:unbuy"
        })
    },
    delete:function(item){
        dispatcher.dispatch({
            payload:item,
            type:"grocery-item:delete"
        })
    }
}
