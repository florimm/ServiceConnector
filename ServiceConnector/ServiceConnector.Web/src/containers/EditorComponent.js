import React, {Component} from 'react';
import FieldsSelector from './../components/FieldsSelector';
import FilterList from './FilterList';

export default class EditorComponent extends Component{
    render(){
        const {group,name} = this.props;
        return (
                <section className="content">
                  <div className="box">
                    <div className="box-header with-border">
                      <h3 className="box-title">Editor</h3>
                      <div className="box-tools pull-right">
                        <button className="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i className="fa fa-minus"></i></button>
                        <button className="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove"><i className="fa fa-times"></i></button>
                      </div>
                    </div>
                    <div className="box-body">
                      <FilterList />
                    </div>
                    <div className="box-footer">
                      Footer
                    </div>
                  </div>
                </section>
            );
    }
} 