import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import store from './redux/reduxStore';

import './index.scss';
import './assets/boxicons-2.0.7/css/boxicons.min.scss';
import './assets/css/grid.scss';
import './assets/css/theme.scss';
import './assets/css/index.scss';

// import App from './App';

import Layout from './components/layout/Layout';

ReactDOM.render(
  <Provider store={store}>
    <React.StrictMode>
      <Layout />
    </React.StrictMode>
  </Provider>,
  document.getElementById('root'),
);
