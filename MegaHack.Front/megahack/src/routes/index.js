import React from 'react';
import { BrowserRouter, Switch } from 'react-router-dom';
import Route from './Route';

import Main from '../pages/Main';
import Register from '../pages/Register';
import Contracts from '../pages/contract';
import Login from '../pages/Login';

export default function Routes() {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/" exact component={Main} isPrivate />
        <Route path="/login" exact component={Login} />
        <Route path="/register" exact component={Register} />
        <Route path="/contracts" exact component={Contracts} isPrivate />
      </Switch>
    </BrowserRouter>
  );
}