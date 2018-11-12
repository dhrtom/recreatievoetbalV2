import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
  </Layout>
);

let deferredPrompt;

window.addEventListener('beforeinstallprompt', (e) => {
    debugger;
    // Prevent Chrome 67 and earlier from automatically showing the prompt
    e.preventDefault();
    // Stash the event so it can be triggered later.
    deferredPrompt = e;
});