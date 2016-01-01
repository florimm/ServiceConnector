import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import FilterList from './FilterList';
import ContentHeader from './../parts/ContentHeader';
import Header from './../parts/Header';
import SideBar from './../parts/SideBar';
import Footer from './../parts/Footer';
import EditorComponent from './EditorComponent';
import * as actionCreators from '../actionCreators';

class App extends Component {
  render() {
    const {selectedFields, availableFields, actions} = this.props;
    return (
      <div>
        <Header/>
        <SideBar/>
        <div className="content-wrapper" style={{minHeight:'976px'}}>
          <ContentHeader projectName="Test"/>
          <EditorComponent/>
        </div>
        <Footer/>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    selectedFields: state.get('selectedFields'),
    availableFields: state.get('availableFields')
  };
}

function mapDispatchToProps(dispatch) {
  return {actions: bindActionCreators(actionCreators, dispatch)};
}

export default connect(mapStateToProps, mapDispatchToProps)(App);
