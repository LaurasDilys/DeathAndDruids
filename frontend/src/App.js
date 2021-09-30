import React from 'react';
import './App.css';
import Combat from './components/Combat';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
// import Home from './pages/Home';
// import Navbar from './nav/Navbar';

const App = () => {
  return (
    <Router>
      {/* <Navbar /> */}
      <Switch>
        {/* <Route path='/' exact component={Home} /> */}
        <Route path='/' component={Combat} />
      </Switch>
    </Router>
  );
}

export default App;
