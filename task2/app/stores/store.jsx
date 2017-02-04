var dispatcher = require('./../dispatcher.js');

function Store() {
    var storedText = "";
    var listeners = [];

    function updateItem(text) {
        storedText= text;
        triggerListeners();
    }

    function onChange(listener) {
        listeners.push(listener);
    }

    function triggerListeners() {
        listeners.forEach(function (listener) {
            listener(storedText);
        })
    };

    dispatcher.register(function (event) {
        var split = event.type.split(':');
        if (split[0] == 'text-change') {
            switch (split[1]) {
                case "update":
                    updateItem(event.payload);
                    break;
            }
        }
    });

    return {
        onChange:onChange
    }
}

module.exports = new Store();