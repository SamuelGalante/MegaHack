import { takeLatest, call, put, all } from 'redux-saga/effects';
import api from '../../../services/api';

export function signIn({ payload }) {
  const { email, password } = payload;

  const response = call(api.post, 'auth', {
    email,
    password
  });

}
export default all([
  takeLatest('@auth/SIGN_IN_REQUEST', signIn)
]);