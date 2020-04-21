import React, { Component } from 'react';
import Cashflow from './components/CashFlow';
import { BrowserRouter , Switch, Route } from 'react-router-dom';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <BrowserRouter>    
      <Switch>
                <Route path="/" exact component={Cashflow} />              
      </Switch>
    </BrowserRouter>
    );
  }
}
