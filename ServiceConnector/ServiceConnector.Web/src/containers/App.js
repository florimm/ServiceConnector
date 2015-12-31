import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import FilterList from './FilterList';
import ServiceComponent from './../components/ServiceComponent';
import EditorComponent from './EditorComponent';
import * as actionCreators from '../actionCreators';

class App extends Component {
  render() {
    const {selectedFields, availableFields, actions} = this.props;
    return (
      <div>
      <header className="main-header">
        <a href="../../index2.html" className="logo">
          <span className="logo-mini"><b>A</b>LT</span>
          <span className="logo-lg"><b>Admin</b>LTE</span>
        </a>
        <nav className="navbar navbar-static-top" role="navigation">
          <a href="#" className="sidebar-toggle" data-toggle="offcanvas" role="button">
            <span className="sr-only">Toggle navigation</span>
            <span className="icon-bar"></span>
            <span className="icon-bar"></span>
            <span className="icon-bar"></span>
          </a>
          <div className="navbar-custom-menu">
            <ul className="nav navbar-nav">
              <li className="dropdown messages-menu">
                <a href="#" className="dropdown-toggle" data-toggle="dropdown">
                  <i className="fa fa-envelope-o"></i>
                  <span className="label label-success">4</span>
                </a>
                <ul className="dropdown-menu">
                  <li className="header">You have 4 messages</li>
                  <li>
                    <ul className="menu">
                      <li>
                        <a href="#">
                          <div className="pull-left">
                            <img src="https://placehold.it/160x160" className="img-circle" alt="User Image"/>
                          </div>
                          <h4>
                            Support Team
                            <small><i className="fa fa-clock-o"></i> 5 mins</small>
                          </h4>
                          <p>Why not buy a new awesome theme?</p>
                        </a>
                      </li>
                    </ul>
                  </li>
                  <li className="footer"><a href="#">See All Messages</a></li>
                </ul>
              </li>
              <li className="dropdown notifications-menu">
                <a href="#" className="dropdown-toggle" data-toggle="dropdown">
                  <i className="fa fa-bell-o"></i>
                  <span className="label label-warning">10</span>
                </a>
                <ul className="dropdown-menu">
                  <li className="header">You have 10 notifications</li>
                  <li>
                    <ul className="menu">
                      <li>
                        <a href="#">
                          <i className="fa fa-users text-aqua"></i> 5 new members joined today
                        </a>
                      </li>
                    </ul>
                  </li>
                  <li className="footer"><a href="#">View all</a></li>
                </ul>
              </li>
              <li className="dropdown tasks-menu">
                <a href="#" className="dropdown-toggle" data-toggle="dropdown">
                  <i className="fa fa-flag-o"></i>
                  <span className="label label-danger">9</span>
                </a>
                <ul className="dropdown-menu">
                  <li className="header">You have 9 tasks</li>
                  <li>
                    <ul className="menu">
                      <li>
                        <a href="#">
                          <h3>
                            Design some buttons
                            <small className="pull-right">20%</small>
                          </h3>
                          <div className="progress xs">
                            <div className="progress-bar progress-bar-aqua" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                              <span className="sr-only">20% Complete</span>
                            </div>
                          </div>
                        </a>
                      </li>
                    </ul>
                  </li>
                  <li className="footer">
                    <a href="#">View all tasks</a>
                  </li>
                </ul>
              </li>
              <li className="dropdown user user-menu">
                <a href="#" className="dropdown-toggle" data-toggle="dropdown">
                  <img src="https://placehold.it/160x160" className="user-image" alt="User Image"/>
                  <span className="hidden-xs">Florim Maxhuni</span>
                </a>
                <ul className="dropdown-menu">
                  <li className="user-header">
                    <img src="https://placehold.it/160x160" className="img-circle" alt="User Image"/>
                    <p>
                      Alexander Pierce - Web Developer
                      <small>Member since Nov. 2012</small>
                    </p>
                  </li>
                  <li className="user-body">
                    <div className="col-xs-4 text-center">
                      <a href="#">Followers</a>
                    </div>
                    <div className="col-xs-4 text-center">
                      <a href="#">Sales</a>
                    </div>
                    <div className="col-xs-4 text-center">
                      <a href="#">Friends</a>
                    </div>
                  </li>
                  <li className="user-footer">
                    <div className="pull-left">
                      <a href="#" className="btn btn-default btn-flat">Profile</a>
                    </div>
                    <div className="pull-right">
                      <a href="#" className="btn btn-default btn-flat">Sign out</a>
                    </div>
                  </li>
                </ul>
              </li>
              <li>
                <a href="#" data-toggle="control-sidebar"><i className="fa fa-gears"></i></a>
              </li>
            </ul>
          </div>
        </nav>
      </header>
      <aside className="main-sidebar">
        <section className="sidebar">
          <div className="user-panel">
            <div className="pull-left image">
              <img src="https://placehold.it/160x160" className="img-circle" alt="User Image"/>
            </div>
            <div className="pull-left info">
              <p>Alexander Pierce</p>
              <a href="#"><i className="fa fa-circle text-success"></i> Online</a>
            </div>
          </div>
          <form action="#" method="get" className="sidebar-form">
            <div className="input-group">
              <input type="text" name="q" className="form-control" placeholder="Search..."/>
              <span className="input-group-btn">
                <button type="submit" name="search" id="search-btn" className="btn btn-flat"><i className="fa fa-search"></i></button>
              </span>
            </div>
          </form>
          <ul className="sidebar-menu">
            <li className="header">MAIN NAVIGATION</li>
            <li className="treeview">
              <a href="#">
                <i className="fa fa-dashboard"></i> <span>Dashboard</span> <i className="fa fa-angle-left pull-right"></i>
              </a>
              <ul className="treeview-menu">
                <li><a href="../../index.html"><i className="fa fa-circle-o"></i><ServiceComponent group="Server" name="SQL"/></a></li>
                <li><a href="../../index2.html"><i className="fa fa-circle-o"></i><ServiceComponent group="Server" name="MySQL"/></a></li>
              </ul>
            </li>
            <li className="treeview active">
              <a href="#">
                <i className="fa fa-files-o"></i>
                <span>Layout Options</span>
                <span className="label label-primary pull-right">4</span>
              </a>
              <ul className="treeview-menu">
                <li><a href="top-nav.html"><i className="fa fa-circle-o"></i> Top Navigation</a></li>
                <li><a href="boxed.html"><i className="fa fa-circle-o"></i> Boxed</a></li>
                <li><a href="fixed.html"><i className="fa fa-circle-o"></i> Fixed</a></li>
                <li className="active"><a href="collapsed-sidebar.html"><i className="fa fa-circle-o"></i> Collapsed Sidebar</a></li>
              </ul>
            </li>
            <li>
              <a href="../widgets.html">
                <i className="fa fa-th"></i> <span>Widgets</span> <small className="label pull-right bg-green">new</small>
              </a>
            </li>
            <li className="treeview">
              <a href="#">
                <i className="fa fa-pie-chart"></i>
                <span>Charts</span>
                <i className="fa fa-angle-left pull-right"></i>
              </a>
              <ul className="treeview-menu">
                <li><a href="../charts/chartjs.html"><i className="fa fa-circle-o"></i> ChartJS</a></li>
                <li><a href="../charts/morris.html"><i className="fa fa-circle-o"></i> Morris</a></li>
                <li><a href="../charts/flot.html"><i className="fa fa-circle-o"></i> Flot</a></li>
                <li><a href="../charts/inline.html"><i className="fa fa-circle-o"></i> Inline charts</a></li>
              </ul>
            </li>
            <li className="treeview">
              <a href="#">
                <i className="fa fa-laptop"></i>
                <span>UI Elements</span>
                <i className="fa fa-angle-left pull-right"></i>
              </a>
              <ul className="treeview-menu">
                <li><a href="../UI/general.html"><i className="fa fa-circle-o"></i> General</a></li>
                <li><a href="../UI/icons.html"><i className="fa fa-circle-o"></i> Icons</a></li>
                <li><a href="../UI/buttons.html"><i className="fa fa-circle-o"></i> Buttons</a></li>
                <li><a href="../UI/sliders.html"><i className="fa fa-circle-o"></i> Sliders</a></li>
                <li><a href="../UI/timeline.html"><i className="fa fa-circle-o"></i> Timeline</a></li>
                <li><a href="../UI/modals.html"><i className="fa fa-circle-o"></i> Modals</a></li>
              </ul>
            </li>
            <li className="treeview">
              <a href="#">
                <i className="fa fa-edit"></i> <span>Forms</span>
                <i className="fa fa-angle-left pull-right"></i>
              </a>
              <ul className="treeview-menu">
                <li><a href="../forms/general.html"><i className="fa fa-circle-o"></i> General Elements</a></li>
                <li><a href="../forms/advanced.html"><i className="fa fa-circle-o"></i> Advanced Elements</a></li>
                <li><a href="../forms/editors.html"><i className="fa fa-circle-o"></i> Editors</a></li>
              </ul>
            </li>
            <li className="treeview">
              <a href="#">
                <i className="fa fa-table"></i> <span>Tables</span>
                <i className="fa fa-angle-left pull-right"></i>
              </a>
              <ul className="treeview-menu">
                <li><a href="../tables/simple.html"><i className="fa fa-circle-o"></i> Simple tables</a></li>
                <li><a href="../tables/data.html"><i className="fa fa-circle-o"></i> Data tables</a></li>
              </ul>
            </li>
            <li>
              <a href="../calendar.html">
                <i className="fa fa-calendar"></i> <span>Calendar</span>
                <small className="label pull-right bg-red">3</small>
              </a>
            </li>
            <li>
              <a href="../mailbox/mailbox.html">
                <i className="fa fa-envelope"></i> <span>Mailbox</span>
                <small className="label pull-right bg-yellow">12</small>
              </a>
            </li>
            <li className="treeview">
              <a href="#">
                <i className="fa fa-folder"></i> <span>Examples</span>
                <i className="fa fa-angle-left pull-right"></i>
              </a>
              <ul className="treeview-menu">
                <li><a href="../examples/invoice.html"><i className="fa fa-circle-o"></i> Invoice</a></li>
                <li><a href="../examples/profile.html"><i className="fa fa-circle-o"></i> Profile</a></li>
                <li><a href="../examples/login.html"><i className="fa fa-circle-o"></i> Login</a></li>
                <li><a href="../examples/register.html"><i className="fa fa-circle-o"></i> Register</a></li>
                <li><a href="../examples/lockscreen.html"><i className="fa fa-circle-o"></i> Lockscreen</a></li>
                <li><a href="../examples/404.html"><i className="fa fa-circle-o"></i> 404 Error</a></li>
                <li><a href="../examples/500.html"><i className="fa fa-circle-o"></i> 500 Error</a></li>
                <li><a href="../examples/blank.html"><i className="fa fa-circle-o"></i> Blank Page</a></li>
              </ul>
            </li>
            <li className="treeview">
              <a href="#">
                <i className="fa fa-share"></i> <span>Multilevel</span>
                <i className="fa fa-angle-left pull-right"></i>
              </a>
              <ul className="treeview-menu">
                <li><a href="#"><i className="fa fa-circle-o"></i> Level One</a></li>
                <li>
                  <a href="#"><i className="fa fa-circle-o"></i> Level One <i className="fa fa-angle-left pull-right"></i></a>
                  <ul className="treeview-menu">
                    <li><a href="#"><i className="fa fa-circle-o"></i> Level Two</a></li>
                    <li>
                      <a href="#"><i className="fa fa-circle-o"></i> Level Two <i className="fa fa-angle-left pull-right"></i></a>
                      <ul className="treeview-menu">
                        <li><a href="#"><i className="fa fa-circle-o"></i> Level Three</a></li>
                        <li><a href="#"><i className="fa fa-circle-o"></i> Level Three</a></li>
                      </ul>
                    </li>
                  </ul>
                </li>
                <li><a href="#"><i className="fa fa-circle-o"></i> Level One</a></li>
              </ul>
            </li>
            <li><a href="../../documentation/index.html"><i className="fa fa-book"></i> <span>Documentation</span></a></li>
            <li className="header">LABELS</li>
            <li><a href="#"><i className="fa fa-circle-o text-red"></i> <span>Important</span></a></li>
            <li><a href="#"><i className="fa fa-circle-o text-yellow"></i> <span>Warning</span></a></li>
            <li><a href="#"><i className="fa fa-circle-o text-aqua"></i> <span>Information</span></a></li>
          </ul>
        </section>
      </aside>
      <div className="content-wrapper" style={{minHeight:'976px'}}>
        <section className="content-header">
          <ol className="breadcrumb">
            <li><a href="#"><i className="fa fa-dashboard"></i> Home</a></li>
            <li><a href="#">Layout</a></li>
            <li className="active">Collapsed Sidebar</li>
          </ol>
        </section>
        <EditorComponent/>
      </div>

      <footer className="main-footer">
        <div className="pull-right hidden-xs">
          <b>Version</b> 2.3.0
        </div>
        <strong>Copyright &copy; 2014-2015 <a href="http://almsaeedstudio.com">Almsaeed Studio</a>.</strong> All rights reserved.
      </footer>
      <aside className="control-sidebar control-sidebar-dark">
        <ul className="nav nav-tabs nav-justified control-sidebar-tabs">
          <li><a href="#control-sidebar-home-tab" data-toggle="tab"><i className="fa fa-home"></i></a></li>
          <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i className="fa fa-gears"></i></a></li>
        </ul>
        <div className="tab-content">
          <div className="tab-pane" id="control-sidebar-home-tab">
            <h3 className="control-sidebar-heading">Recent Activity</h3>
            <ul className="control-sidebar-menu">
              <li>
                <a href="javascript::;">
                  <i className="menu-icon fa fa-birthday-cake bg-red"></i>
                  <div className="menu-info">
                    <h4 className="control-sidebar-subheading">Langdons Birthday</h4>
                    <p>Will be 23 on April 24th</p>
                  </div>
                </a>
              </li>
              <li>
                <a href="javascript::;">
                  <i className="menu-icon fa fa-user bg-yellow"></i>
                  <div className="menu-info">
                    <h4 className="control-sidebar-subheading">Frodo Updated His Profile</h4>
                    <p>New phone +1(800)555-1234</p>
                  </div>
                </a>
              </li>
              <li>
                <a href="javascript::;">
                  <i className="menu-icon fa fa-envelope-o bg-light-blue"></i>
                  <div className="menu-info">
                    <h4 className="control-sidebar-subheading">Nora Joined Mailing List</h4>
                    <p>nora@example.com</p>
                  </div>
                </a>
              </li>
              <li>
                <a href="javascript::;">
                  <i className="menu-icon fa fa-file-code-o bg-green"></i>
                  <div className="menu-info">
                    <h4 className="control-sidebar-subheading">Cron Job 254 Executed</h4>
                    <p>Execution time 5 seconds</p>
                  </div>
                </a>
              </li>
            </ul>

            <h3 className="control-sidebar-heading">Tasks Progress</h3>
            <ul className="control-sidebar-menu">
              <li>
                <a href="javascript::;">
                  <h4 className="control-sidebar-subheading">
                    Custom Template Design
                    <span className="label label-danger pull-right">70%</span>
                  </h4>
                  <div className="progress progress-xxs">
                    <div className="progress-bar progress-bar-danger"></div>
                  </div>
                </a>
              </li>
              <li>
                <a href="javascript::;">
                  <h4 className="control-sidebar-subheading">
                    Update Resume
                    <span className="label label-success pull-right">95%</span>
                  </h4>
                  <div className="progress progress-xxs">
                    <div className="progress-bar progress-bar-success"></div>
                  </div>
                </a>
              </li>
              <li>
                <a href="javascript::;">
                  <h4 className="control-sidebar-subheading">
                    Laravel Integration
                    <span className="label label-warning pull-right">50%</span>
                  </h4>
                  <div className="progress progress-xxs">
                    <div className="progress-bar progress-bar-warning"></div>
                  </div>
                </a>
              </li>
              <li>
                <a href="javascript::;">
                  <h4 className="control-sidebar-subheading">
                    Back End Framework
                    <span className="label label-primary pull-right">68%</span>
                  </h4>
                  <div className="progress progress-xxs">
                    <div className="progress-bar progress-bar-primary"></div>
                  </div>
                </a>
              </li>
            </ul>

          </div>
          <div className="tab-pane" id="control-sidebar-stats-tab">Stats Tab Content</div>
          <div className="tab-pane" id="control-sidebar-settings-tab">
            <form method="post">
              <h3 className="control-sidebar-heading">General Settings</h3>
              <div className="form-group">
                <label className="control-sidebar-subheading">
                  Report panel usage
                  <input type="checkbox" className="pull-right"/>
                </label>
                <p>
                  Some information about this general settings option
                </p>
              </div>

              <div className="form-group">
                <label className="control-sidebar-subheading">
                  Allow mail redirect
                  <input type="checkbox" className="pull-right"/>
                </label>
                <p>
                  Other sets of options are available
                </p>
              </div>

              <div className="form-group">
                <label className="control-sidebar-subheading">
                  Expose author name in posts
                  <input type="checkbox" className="pull-right"/>
                </label>
                <p>
                  Allow the user to show his name in blog posts
                </p>
              </div>

              <h3 className="control-sidebar-heading">Chat Settings</h3>

              <div className="form-group">
                <label className="control-sidebar-subheading">
                  Show me as online
                  <input type="checkbox" className="pull-right"/>
                </label>
              </div>

              <div className="form-group">
                <label className="control-sidebar-subheading">
                  Turn off notifications
                  <input type="checkbox" className="pull-right"/>
                </label>
              </div>

              <div className="form-group">
                <label className="control-sidebar-subheading">
                  Delete chat history
                  <a href="javascript::;" className="text-red pull-right"><i className="fa fa-trash-o"></i></a>
                </label>
              </div>
            </form>
          </div>
        </div>
      </aside>
      <div className="control-sidebar-bg"></div>

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
