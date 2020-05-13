import React, { Component } from 'react';
import Web3 from 'web3';
import { TODO_LIST_ABI, TODO_LIST_ADDRESS } from './config';

class Contract extends Component {
  constructor(props) {
    super(props);
    this.state = {
      account: '',
      model: '',
      text: '',
      contract: null
   };
   this.handleChange = this.handleChange.bind(this);
  }

  componentWillMount() {
    this.loadBlockchainData()
  }

  async loadBlockchainData() {
    const web3 = new Web3(Web3.givenProvider);
    const contract = new web3.eth.Contract(TODO_LIST_ABI, TODO_LIST_ADDRESS);
    const accounts = await web3.eth.getAccounts();

    this.setState({ account: accounts[0] });
    this.setState({ contract });
  }

  async handleGetValue() {
    const { contract } = this.state;
    const model = await contract.methods.getInfo().call();
    
    this.setState({ model });
    console.log("task: ", model);
  }

  async handleSetValue(event) {
    const { contract, account } = this.state;
    console.log("Account:", account)
    this.setState({ text: event.target.value});
    await contract.methods.set(event.target.value).send({ from: account }).then( function(tx) { 
      console.log("Transaction: ", tx); 
    });
  }

  handleChange(event) {
    this.setState({text: event.target.value});
  }

  render() {
    const { model, text } = this.state;
    return (
      <>
      <h1 class="page-header">Register information at Blockchain - RSK network</h1>
      <div class="row">
        <div>
          <h3 class="sub-header">Set information</h3>
          <form class="form-inline">
            <div class="form-group">
              <table>
                <tr>
                  <td><label for="newInfo">Info:</label> </td>
                  <td>
                    <input type="text" value={this.state.text} onChange={this.handleChange} />
                  </td>                          
                </tr>
              </table>
            </div>
            <button onclick={this.handleSetValue} class="btn btn-primary">Set</button>
            <p>{text}</p>
          </form>
        </div>
      </div>    
      <div class="row">
        <div>
          <h3 class="sub-header">Get last information saved</h3>
          <form class="form-inline">
            <button onclick={this.handleGetValue} class="btn btn-primary">Get</button>
            <div class="form-group">
              <table>
                <tr>
                  <td>Info: {model}</td>
                  <td>
                    <label id="lastInfo" />
                  </td>                          
                </tr>
              </table>
            </div>                
          </form>
        </div>
      </div>
      </>
    );
  }
}

export default Contract;