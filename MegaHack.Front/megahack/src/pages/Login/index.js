import React from 'react';
import { Link } from 'react-router-dom';
import { Form, Input } from '@rocketseat/unform';
import api from '../../services/api';

function Login() {
  async function  handleSubmit(data)  {
    var response = await api.post(`/User/auth`,{
      ...data
    })
    console.log("data: ", data)
  }
  return (
    <>
      <img alt="logo"/>
      
      <Form onSubmit={handleSubmit}>
        <Input name="username" type="email" placeholder="Seu e-mail"/>
        <Input name="password" type="password" placeholder="Sua senha"/>

        <button type="submit">Acessar</button>
        <Link to="/register">Criar conta</Link>
      </Form>
    </>
  );
}

export default Login;