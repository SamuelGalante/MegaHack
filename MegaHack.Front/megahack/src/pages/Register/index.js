import React from 'react';
import { Link } from 'react-router-dom';
import { Form, Input } from '@rocketseat/unform';

function Register() {
  function handleSubmit(data) {
    console.log("data: ", data)
  }
  return (
    <>
      <img alt="logo"/>
      
      <Form onSubmit={handleSubmit}>
        <Input name="nome" type="text" placeholder="Seu nome"/>
        <Input name="email" type="email" placeholder="Seu e-mail"/>
        <Input name="password" type="password" placeholder="Sua senha"/>

        <button type="submit">Criar conta</button>
        <Link to="/login">Ja tenho login</Link>
      </Form>
    </>
  );
}

export default Register;