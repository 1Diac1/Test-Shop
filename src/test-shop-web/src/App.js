import React from 'react';
// import { BrowserRouter, Route } from 'react-router-dom';

import Header from './components/Header/Header';
// import Navbar from './components/Navbar/Navbar';

const App = () => {
  return (
    // <BrowserRouter>
    //   <div className="Wrapper">
    //     <div className="head">
    <Header />
    //     </div>
    //     <div className="navigation">
    //       <Navbar />
    //     </div>
    //     <div className="content container">
    //       <div className="contant_midl">
    //         <Route exact path="/profile/:userId?" render={() => <ProfileContainer />} />

    //         <Route path="/messages" render={() => <MessagesContainer />} />
    //       </div>
    //     </div>
    //   </div>
    // </BrowserRouter>
  );
};

export default App;
