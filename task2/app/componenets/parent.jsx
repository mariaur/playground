var React = require('react');
var ChildInput = require('./ChildInput.jsx');
var ChildOutput = require('./ChildOutput.jsx');

module.exports = class Parent extends React.Component {
    render() {
        return (
            <div>
                <h1> Some Parent Title </h1>
                <ChildInput />
                <ChildOutput input={this.props._text}/>
            </div>
        )
    }
}
//   <ChileOutput {this.props.text}/>
/* {this.props.input.text(function (_text) {
                    return (
                        <Text text={_text} key={_text}/>
                    )
                })} */