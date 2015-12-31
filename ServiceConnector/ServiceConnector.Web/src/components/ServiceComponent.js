import React, {Component} from 'react';

export default class ServiceComponent extends Component{
    render(){
        const {group,name} = this.props;
        return (<span>{group} {name}</span>);
    }
} 