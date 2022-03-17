import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';

import './assets/boxicons-2.0.7/css/boxicons.min.scss';
import './assets/css/grid.scss';
import './assets/css/index.scss';

import Header from './components/Header/Header';
import SearchBar from './components/SearchBar/SearchBar';
import RoutesShop from './components/RoutesShop';
// import Navbar from './components/Navbar/Navbar';

const App = () => {
  return (
    <BrowserRouter>
      <Route
        path="/"
        render={(props) => (
          <div>
            <Header {...props} />
            <div className="layout__content">
              {/* <SearchBar /> */}
              <div className="layout__content-main">
                <RoutesShop />
              </div>
            </div>
          </div>
        )}
      />
    </BrowserRouter>
  );
};

export default App;
