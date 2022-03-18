import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import store from './redux/reduxStore';
import { Switch, Route, BrowserRouter } from 'react-router-dom';

import './index.scss';
import './assets/boxicons-2.0.7/css/boxicons.min.scss';
import './assets/css/grid.scss';
import './assets/css/theme.scss';
import './assets/css/index.scss';

import App from './App';
import AdminPanel from './components/AdminPanel/AdminPanel';

ReactDOM.render(
  <Provider store={store}>
    <React.StrictMode>
      <BrowserRouter>
        <Switch>
          <Route path="/" exact component={App} />
          <Route path="/administration" exact component={AdminPanel} />
        </Switch>
      </BrowserRouter>
    </React.StrictMode>
  </Provider>,
  document.getElementById('root'),
);
