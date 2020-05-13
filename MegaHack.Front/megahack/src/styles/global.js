import { createGlobalStyle } from 'styled-components';

export default createGlobalStyle `
  @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@100&display=swap');
  * {
    margin: 0;
    padding: 0;
    outline: 0;
    box-sizing: border-box;
  }

  *:focus {
    outline: 0;
  }

  html, body, #root {
    height: 100%
  }

  body {
    /* background: linear-gradient(-90deg, #17d3c7, #004562); */
    -webkit-font-smoothing: antialiased !important;
  }

  body, input, button {
    color: #222;
    font-size: 14px;
    font-family: 'Roboto', sans-serif;
  }

  a {
    text-decoration: none;
  }

  ul {
    list-style: none;
  }

  button {
    cursor: pointer;
  }
`;