var dispatcher = require('./../dispatcher.js');

module.exports = {
    update:function(item){
        dispatcher.dispatch({
            payload:item,
            type:"text-change:update"
        })
    }
}
