import React from 'react';
import { ApolloProvider } from '@apollo/react-hooks';
import { BrowserRouter, Route } from 'react-router-dom';
import apolloClient from './config/apolloClient';

const App = () => (
    <ApolloProvider client={apolloClient}>
        <BrowserRouter>
            <Route path="/" component={() => "hello"} />
        </BrowserRouter>
    </ApolloProvider>
)

export default App;
