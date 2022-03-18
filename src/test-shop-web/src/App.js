import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';

import './assets/boxicons-2.0.7/css/boxicons.min.scss';
import './assets/css/grid.scss';
import './assets/css/index.scss';

import RoutesShop from './components/RoutesShop';
// import Navbar from './components/Navbar/Navbar';
import HeaderMenu from './components/Header/HeaderMenu/HeaderMenu';
import HeaderSearch from './components/Header/HeaderSearch/HeaderSearch';

const App = () => {
  return (
    <BrowserRouter>
      <Route
        path="/"
        render={(props) => (
          <div>
            <HeaderSearch />
            <HeaderMenu {...props} />
            <div className="shop__content-main">
              <RoutesShop />
            </div>
            <div className="footer"></div>
          </div>
        )}
      />
    </BrowserRouter>
  );
};

export default App;
