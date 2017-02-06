var React = require('react');
var ChildInput = require('./ChildInput.jsx');
var ChildOutput = require('./ChildOutput.jsx');

module.exports = class Parent extends React.Component {
    render() {
        var containerStyle = {
            fontFamily: '"Lato", sans-serif',
            padding: '0 0 30px 0',
            backgroundColor: '4298f4',
            border: "1px solid black"
          
        };

        var textStyle = {
              color: 'ffffff',
              textAlign:'center'

        }

        return (
            <div className="container-fluid text-center">
                <div style={containerStyle}>
                    <div className="row-fluid text-center">
                        <div className="col-md-12">
                            <h1 style={textStyle}> Some Parent Title </h1>
                        </div>
                    </div>
                    <div className="row-fluid"></div>
                    <div className="row-fluid"></div>
                    <div className="row-fluid">
                        <div className="col-md-6">
                            <ChildOutput input={this.props.text ? this.props.text.name : ""} />
                        </div>
                        <div className="col-md-6">
                            <ChildInput />
                        </div>
                    </div>
                    <div className="row">
                    <div className="col-md-8">
                </div>
                </div>
                </div>
            </div>
        )
    }
}
