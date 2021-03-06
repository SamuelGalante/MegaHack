import React from 'react';
import { Route, Redirect } from 'react-router-dom';

import AuthLayout from '../pages/_layouts/auth';
import DefaultLayout from '../pages/_layouts/default';

export default function RouteWrapper({
  component: Component,
  isPrivate = false,
  ...rest
}) {
  const signed = false;

  if (!signed && isPrivate) {
    return <Redirect to="/login"/>;
  }

  if (signed && !isPrivate) {
    return <Redirect to="/"/>;
  }

  const Layout = signed ? DefaultLayout : AuthLayout;

  return (
    <Route {...rest} render={props => (
      <Layout>
        <Component {...props}/>
      </Layout>
    )} />
  );
}