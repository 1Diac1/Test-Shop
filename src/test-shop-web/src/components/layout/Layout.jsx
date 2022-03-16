import React, { useEffect } from 'react';

import './layout.scss';

import Sidebar from '../sidebar/Sidebar';
import TopNav from '../topnav/TopNav';
import Routes from '../Routes';

import { BrowserRouter, Route } from 'react-router-dom';

import { useSelector, useDispatch } from 'react-redux';

import { setMode, setColor } from '../../redux/themeReducer';

const Layout = () => {
  const themeReducer = useSelector((state) => state.ThemeReducer);

  const dispatch = useDispatch();

  useEffect(() => {
    const themeClass = localStorage.getItem('themeMode', 'theme-mode-light');

    const colorClass = localStorage.getItem('colorMode', 'theme-mode-light');

    dispatch(setMode(themeClass));

    dispatch(setColor(colorClass));
  }, [dispatch]);

  return (
    <BrowserRouter>
      <Route
        path="/administration"
        render={(props) => (
          <div className={`layout ${themeReducer.mode} ${themeReducer.color}`}>
            <Sidebar {...props} />
            <div className="layout__content">
              <TopNav />
              <div className="layout__content-main">
                <Routes />
              </div>
            </div>
          </div>
        )}
      />
    </BrowserRouter>
  );
};

export default Layout;
