﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lab3new
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="KHL_base")]
	public partial class myLeagueDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertplayer_stats_tbl(player_stats_tbl instance);
    partial void Updateplayer_stats_tbl(player_stats_tbl instance);
    partial void Deleteplayer_stats_tbl(player_stats_tbl instance);
    partial void Insertplayer_team_history(player_team_history instance);
    partial void Updateplayer_team_history(player_team_history instance);
    partial void Deleteplayer_team_history(player_team_history instance);
    partial void Insertplayer_tbl(player_tbl instance);
    partial void Updateplayer_tbl(player_tbl instance);
    partial void Deleteplayer_tbl(player_tbl instance);
    partial void Insertteam_tbl(team_tbl instance);
    partial void Updateteam_tbl(team_tbl instance);
    partial void Deleteteam_tbl(team_tbl instance);
    partial void Insertgame_tbl(game_tbl instance);
    partial void Updategame_tbl(game_tbl instance);
    partial void Deletegame_tbl(game_tbl instance);
    #endregion
		
		public myLeagueDataContext() : 
				base(global::lab3new.Properties.Settings.Default.KHL_baseConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public myLeagueDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public myLeagueDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public myLeagueDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public myLeagueDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<player_stats_tbl> player_stats_tbls
		{
			get
			{
				return this.GetTable<player_stats_tbl>();
			}
		}
		
		public System.Data.Linq.Table<player_team_history> player_team_histories
		{
			get
			{
				return this.GetTable<player_team_history>();
			}
		}
		
		public System.Data.Linq.Table<player_tbl> player_tbls
		{
			get
			{
				return this.GetTable<player_tbl>();
			}
		}
		
		public System.Data.Linq.Table<team_tbl> team_tbls
		{
			get
			{
				return this.GetTable<team_tbl>();
			}
		}
		
		public System.Data.Linq.Table<game_tbl> game_tbls
		{
			get
			{
				return this.GetTable<game_tbl>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.player_stats_tbl")]
	public partial class player_stats_tbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _player_stats_ID;
		
		private int _player_ID;
		
		private int _game_ID;
		
		private int _goals;
		
		private int _penalties;
		
		private int _assists;
		
		private int _min_played;
		
		private EntityRef<player_tbl> _player_tbl;
		
		private EntityRef<game_tbl> _game_tbl;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onplayer_stats_IDChanging(int value);
    partial void Onplayer_stats_IDChanged();
    partial void Onplayer_IDChanging(int value);
    partial void Onplayer_IDChanged();
    partial void Ongame_IDChanging(int value);
    partial void Ongame_IDChanged();
    partial void OngoalsChanging(int value);
    partial void OngoalsChanged();
    partial void OnpenaltiesChanging(int value);
    partial void OnpenaltiesChanged();
    partial void OnassistsChanging(int value);
    partial void OnassistsChanged();
    partial void Onmin_playedChanging(int value);
    partial void Onmin_playedChanged();
    #endregion
		
		public player_stats_tbl()
		{
			this._player_tbl = default(EntityRef<player_tbl>);
			this._game_tbl = default(EntityRef<game_tbl>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_player_stats_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int player_stats_ID
		{
			get
			{
				return this._player_stats_ID;
			}
			set
			{
				if ((this._player_stats_ID != value))
				{
					this.Onplayer_stats_IDChanging(value);
					this.SendPropertyChanging();
					this._player_stats_ID = value;
					this.SendPropertyChanged("player_stats_ID");
					this.Onplayer_stats_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_player_ID", DbType="Int NOT NULL")]
		public int player_ID
		{
			get
			{
				return this._player_ID;
			}
			set
			{
				if ((this._player_ID != value))
				{
					if (this._player_tbl.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onplayer_IDChanging(value);
					this.SendPropertyChanging();
					this._player_ID = value;
					this.SendPropertyChanged("player_ID");
					this.Onplayer_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_game_ID", DbType="Int NOT NULL")]
		public int game_ID
		{
			get
			{
				return this._game_ID;
			}
			set
			{
				if ((this._game_ID != value))
				{
					if (this._game_tbl.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Ongame_IDChanging(value);
					this.SendPropertyChanging();
					this._game_ID = value;
					this.SendPropertyChanged("game_ID");
					this.Ongame_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_goals", DbType="Int NOT NULL")]
		public int goals
		{
			get
			{
				return this._goals;
			}
			set
			{
				if ((this._goals != value))
				{
					this.OngoalsChanging(value);
					this.SendPropertyChanging();
					this._goals = value;
					this.SendPropertyChanged("goals");
					this.OngoalsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_penalties", DbType="Int NOT NULL")]
		public int penalties
		{
			get
			{
				return this._penalties;
			}
			set
			{
				if ((this._penalties != value))
				{
					this.OnpenaltiesChanging(value);
					this.SendPropertyChanging();
					this._penalties = value;
					this.SendPropertyChanged("penalties");
					this.OnpenaltiesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_assists", DbType="Int NOT NULL")]
		public int assists
		{
			get
			{
				return this._assists;
			}
			set
			{
				if ((this._assists != value))
				{
					this.OnassistsChanging(value);
					this.SendPropertyChanging();
					this._assists = value;
					this.SendPropertyChanged("assists");
					this.OnassistsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[min played]", Storage="_min_played", DbType="Int NOT NULL")]
		public int min_played
		{
			get
			{
				return this._min_played;
			}
			set
			{
				if ((this._min_played != value))
				{
					this.Onmin_playedChanging(value);
					this.SendPropertyChanging();
					this._min_played = value;
					this.SendPropertyChanged("min_played");
					this.Onmin_playedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="player_tbl_player_stats_tbl", Storage="_player_tbl", ThisKey="player_ID", OtherKey="player_ID", IsForeignKey=true)]
		public player_tbl player_tbl
		{
			get
			{
				return this._player_tbl.Entity;
			}
			set
			{
				player_tbl previousValue = this._player_tbl.Entity;
				if (((previousValue != value) 
							|| (this._player_tbl.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._player_tbl.Entity = null;
						previousValue.player_stats_tbls.Remove(this);
					}
					this._player_tbl.Entity = value;
					if ((value != null))
					{
						value.player_stats_tbls.Add(this);
						this._player_ID = value.player_ID;
					}
					else
					{
						this._player_ID = default(int);
					}
					this.SendPropertyChanged("player_tbl");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="game_tbl_player_stats_tbl", Storage="_game_tbl", ThisKey="game_ID", OtherKey="game_ID", IsForeignKey=true)]
		public game_tbl game_tbl
		{
			get
			{
				return this._game_tbl.Entity;
			}
			set
			{
				game_tbl previousValue = this._game_tbl.Entity;
				if (((previousValue != value) 
							|| (this._game_tbl.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._game_tbl.Entity = null;
						previousValue.player_stats_tbls.Remove(this);
					}
					this._game_tbl.Entity = value;
					if ((value != null))
					{
						value.player_stats_tbls.Add(this);
						this._game_ID = value.game_ID;
					}
					else
					{
						this._game_ID = default(int);
					}
					this.SendPropertyChanged("game_tbl");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.player_team_history")]
	public partial class player_team_history : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _player_ID;
		
		private int _team_ID;
		
		private System.DateTime _start_date;
		
		private System.DateTime _end_date;
		
		private EntityRef<player_tbl> _player_tbl;
		
		private EntityRef<team_tbl> _team_tbl;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void Onplayer_IDChanging(int value);
    partial void Onplayer_IDChanged();
    partial void Onteam_IDChanging(int value);
    partial void Onteam_IDChanged();
    partial void Onstart_dateChanging(System.DateTime value);
    partial void Onstart_dateChanged();
    partial void Onend_dateChanging(System.DateTime value);
    partial void Onend_dateChanged();
    #endregion
		
		public player_team_history()
		{
			this._player_tbl = default(EntityRef<player_tbl>);
			this._team_tbl = default(EntityRef<team_tbl>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_player_ID", DbType="Int NOT NULL")]
		public int player_ID
		{
			get
			{
				return this._player_ID;
			}
			set
			{
				if ((this._player_ID != value))
				{
					if (this._player_tbl.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onplayer_IDChanging(value);
					this.SendPropertyChanging();
					this._player_ID = value;
					this.SendPropertyChanged("player_ID");
					this.Onplayer_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_team_ID", DbType="Int NOT NULL")]
		public int team_ID
		{
			get
			{
				return this._team_ID;
			}
			set
			{
				if ((this._team_ID != value))
				{
					if (this._team_tbl.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onteam_IDChanging(value);
					this.SendPropertyChanging();
					this._team_ID = value;
					this.SendPropertyChanged("team_ID");
					this.Onteam_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_start_date", DbType="Date NOT NULL")]
		public System.DateTime start_date
		{
			get
			{
				return this._start_date;
			}
			set
			{
				if ((this._start_date != value))
				{
					this.Onstart_dateChanging(value);
					this.SendPropertyChanging();
					this._start_date = value;
					this.SendPropertyChanged("start_date");
					this.Onstart_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_end_date", DbType="Date NOT NULL")]
		public System.DateTime end_date
		{
			get
			{
				return this._end_date;
			}
			set
			{
				if ((this._end_date != value))
				{
					this.Onend_dateChanging(value);
					this.SendPropertyChanging();
					this._end_date = value;
					this.SendPropertyChanged("end_date");
					this.Onend_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="player_tbl_player_team_history", Storage="_player_tbl", ThisKey="player_ID", OtherKey="player_ID", IsForeignKey=true)]
		public player_tbl player_tbl
		{
			get
			{
				return this._player_tbl.Entity;
			}
			set
			{
				player_tbl previousValue = this._player_tbl.Entity;
				if (((previousValue != value) 
							|| (this._player_tbl.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._player_tbl.Entity = null;
						previousValue.player_team_histories.Remove(this);
					}
					this._player_tbl.Entity = value;
					if ((value != null))
					{
						value.player_team_histories.Add(this);
						this._player_ID = value.player_ID;
					}
					else
					{
						this._player_ID = default(int);
					}
					this.SendPropertyChanged("player_tbl");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="team_tbl_player_team_history", Storage="_team_tbl", ThisKey="team_ID", OtherKey="team_ID", IsForeignKey=true)]
		public team_tbl team_tbl
		{
			get
			{
				return this._team_tbl.Entity;
			}
			set
			{
				team_tbl previousValue = this._team_tbl.Entity;
				if (((previousValue != value) 
							|| (this._team_tbl.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._team_tbl.Entity = null;
						previousValue.player_team_histories.Remove(this);
					}
					this._team_tbl.Entity = value;
					if ((value != null))
					{
						value.player_team_histories.Add(this);
						this._team_ID = value.team_ID;
					}
					else
					{
						this._team_ID = default(int);
					}
					this.SendPropertyChanged("team_tbl");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.player_tbl")]
	public partial class player_tbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _player_ID;
		
		private string _firstname;
		
		private string _lastname;
		
		private System.Nullable<System.DateTime> _birthdate;
		
		private double _height;
		
		private double _weight;
		
		private decimal _salary;
		
		private int _current_team_ID;
		
		private System.Nullable<System.DateTime> _retired;
		
		private EntitySet<player_stats_tbl> _player_stats_tbls;
		
		private EntitySet<player_team_history> _player_team_histories;
		
		private EntityRef<team_tbl> _team_tbl;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onplayer_IDChanging(int value);
    partial void Onplayer_IDChanged();
    partial void OnfirstnameChanging(string value);
    partial void OnfirstnameChanged();
    partial void OnlastnameChanging(string value);
    partial void OnlastnameChanged();
    partial void OnbirthdateChanging(System.Nullable<System.DateTime> value);
    partial void OnbirthdateChanged();
    partial void OnheightChanging(double value);
    partial void OnheightChanged();
    partial void OnweightChanging(double value);
    partial void OnweightChanged();
    partial void OnsalaryChanging(decimal value);
    partial void OnsalaryChanged();
    partial void Oncurrent_team_IDChanging(int value);
    partial void Oncurrent_team_IDChanged();
    partial void OnretiredChanging(System.Nullable<System.DateTime> value);
    partial void OnretiredChanged();
    #endregion
		
		public player_tbl()
		{
			this._player_stats_tbls = new EntitySet<player_stats_tbl>(new Action<player_stats_tbl>(this.attach_player_stats_tbls), new Action<player_stats_tbl>(this.detach_player_stats_tbls));
			this._player_team_histories = new EntitySet<player_team_history>(new Action<player_team_history>(this.attach_player_team_histories), new Action<player_team_history>(this.detach_player_team_histories));
			this._team_tbl = default(EntityRef<team_tbl>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_player_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int player_ID
		{
			get
			{
				return this._player_ID;
			}
			set
			{
				if ((this._player_ID != value))
				{
					this.Onplayer_IDChanging(value);
					this.SendPropertyChanging();
					this._player_ID = value;
					this.SendPropertyChanged("player_ID");
					this.Onplayer_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_firstname", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string firstname
		{
			get
			{
				return this._firstname;
			}
			set
			{
				if ((this._firstname != value))
				{
					this.OnfirstnameChanging(value);
					this.SendPropertyChanging();
					this._firstname = value;
					this.SendPropertyChanged("firstname");
					this.OnfirstnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lastname", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string lastname
		{
			get
			{
				return this._lastname;
			}
			set
			{
				if ((this._lastname != value))
				{
					this.OnlastnameChanging(value);
					this.SendPropertyChanging();
					this._lastname = value;
					this.SendPropertyChanged("lastname");
					this.OnlastnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_birthdate", DbType="Date")]
		public System.Nullable<System.DateTime> birthdate
		{
			get
			{
				return this._birthdate;
			}
			set
			{
				if ((this._birthdate != value))
				{
					this.OnbirthdateChanging(value);
					this.SendPropertyChanging();
					this._birthdate = value;
					this.SendPropertyChanged("birthdate");
					this.OnbirthdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_height", DbType="Float NOT NULL")]
		public double height
		{
			get
			{
				return this._height;
			}
			set
			{
				if ((this._height != value))
				{
					this.OnheightChanging(value);
					this.SendPropertyChanging();
					this._height = value;
					this.SendPropertyChanged("height");
					this.OnheightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_weight", DbType="Float NOT NULL")]
		public double weight
		{
			get
			{
				return this._weight;
			}
			set
			{
				if ((this._weight != value))
				{
					this.OnweightChanging(value);
					this.SendPropertyChanging();
					this._weight = value;
					this.SendPropertyChanged("weight");
					this.OnweightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_salary", DbType="Money NOT NULL")]
		public decimal salary
		{
			get
			{
				return this._salary;
			}
			set
			{
				if ((this._salary != value))
				{
					this.OnsalaryChanging(value);
					this.SendPropertyChanging();
					this._salary = value;
					this.SendPropertyChanged("salary");
					this.OnsalaryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_current_team_ID", DbType="Int NOT NULL")]
		public int current_team_ID
		{
			get
			{
				return this._current_team_ID;
			}
			set
			{
				if ((this._current_team_ID != value))
				{
					if (this._team_tbl.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Oncurrent_team_IDChanging(value);
					this.SendPropertyChanging();
					this._current_team_ID = value;
					this.SendPropertyChanged("current_team_ID");
					this.Oncurrent_team_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_retired", DbType="Date")]
		public System.Nullable<System.DateTime> retired
		{
			get
			{
				return this._retired;
			}
			set
			{
				if ((this._retired != value))
				{
					this.OnretiredChanging(value);
					this.SendPropertyChanging();
					this._retired = value;
					this.SendPropertyChanged("retired");
					this.OnretiredChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="player_tbl_player_stats_tbl", Storage="_player_stats_tbls", ThisKey="player_ID", OtherKey="player_ID")]
		public EntitySet<player_stats_tbl> player_stats_tbls
		{
			get
			{
				return this._player_stats_tbls;
			}
			set
			{
				this._player_stats_tbls.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="player_tbl_player_team_history", Storage="_player_team_histories", ThisKey="player_ID", OtherKey="player_ID")]
		public EntitySet<player_team_history> player_team_histories
		{
			get
			{
				return this._player_team_histories;
			}
			set
			{
				this._player_team_histories.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="team_tbl_player_tbl", Storage="_team_tbl", ThisKey="current_team_ID", OtherKey="team_ID", IsForeignKey=true)]
		public team_tbl team_tbl
		{
			get
			{
				return this._team_tbl.Entity;
			}
			set
			{
				team_tbl previousValue = this._team_tbl.Entity;
				if (((previousValue != value) 
							|| (this._team_tbl.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._team_tbl.Entity = null;
						previousValue.player_tbls.Remove(this);
					}
					this._team_tbl.Entity = value;
					if ((value != null))
					{
						value.player_tbls.Add(this);
						this._current_team_ID = value.team_ID;
					}
					else
					{
						this._current_team_ID = default(int);
					}
					this.SendPropertyChanged("team_tbl");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_player_stats_tbls(player_stats_tbl entity)
		{
			this.SendPropertyChanging();
			entity.player_tbl = this;
		}
		
		private void detach_player_stats_tbls(player_stats_tbl entity)
		{
			this.SendPropertyChanging();
			entity.player_tbl = null;
		}
		
		private void attach_player_team_histories(player_team_history entity)
		{
			this.SendPropertyChanging();
			entity.player_tbl = this;
		}
		
		private void detach_player_team_histories(player_team_history entity)
		{
			this.SendPropertyChanging();
			entity.player_tbl = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.team_tbl")]
	public partial class team_tbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _team_ID;
		
		private string _name;
		
		private string _location;
		
		private EntitySet<player_team_history> _player_team_histories;
		
		private EntitySet<player_tbl> _player_tbls;
		
		private EntitySet<game_tbl> _game_tbls;
		
		private EntitySet<game_tbl> _game_tbls1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onteam_IDChanging(int value);
    partial void Onteam_IDChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnlocationChanging(string value);
    partial void OnlocationChanged();
    #endregion
		
		public team_tbl()
		{
			this._player_team_histories = new EntitySet<player_team_history>(new Action<player_team_history>(this.attach_player_team_histories), new Action<player_team_history>(this.detach_player_team_histories));
			this._player_tbls = new EntitySet<player_tbl>(new Action<player_tbl>(this.attach_player_tbls), new Action<player_tbl>(this.detach_player_tbls));
			this._game_tbls = new EntitySet<game_tbl>(new Action<game_tbl>(this.attach_game_tbls), new Action<game_tbl>(this.detach_game_tbls));
			this._game_tbls1 = new EntitySet<game_tbl>(new Action<game_tbl>(this.attach_game_tbls1), new Action<game_tbl>(this.detach_game_tbls1));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_team_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int team_ID
		{
			get
			{
				return this._team_ID;
			}
			set
			{
				if ((this._team_ID != value))
				{
					this.Onteam_IDChanging(value);
					this.SendPropertyChanging();
					this._team_ID = value;
					this.SendPropertyChanged("team_ID");
					this.Onteam_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_location", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string location
		{
			get
			{
				return this._location;
			}
			set
			{
				if ((this._location != value))
				{
					this.OnlocationChanging(value);
					this.SendPropertyChanging();
					this._location = value;
					this.SendPropertyChanged("location");
					this.OnlocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="team_tbl_player_team_history", Storage="_player_team_histories", ThisKey="team_ID", OtherKey="team_ID")]
		public EntitySet<player_team_history> player_team_histories
		{
			get
			{
				return this._player_team_histories;
			}
			set
			{
				this._player_team_histories.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="team_tbl_player_tbl", Storage="_player_tbls", ThisKey="team_ID", OtherKey="current_team_ID")]
		public EntitySet<player_tbl> player_tbls
		{
			get
			{
				return this._player_tbls;
			}
			set
			{
				this._player_tbls.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="team_tbl_game_tbl", Storage="_game_tbls", ThisKey="team_ID", OtherKey="away_team_ID")]
		public EntitySet<game_tbl> game_tbls
		{
			get
			{
				return this._game_tbls;
			}
			set
			{
				this._game_tbls.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="team_tbl_game_tbl1", Storage="_game_tbls1", ThisKey="team_ID", OtherKey="home_team_ID")]
		public EntitySet<game_tbl> game_tbls1
		{
			get
			{
				return this._game_tbls1;
			}
			set
			{
				this._game_tbls1.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_player_team_histories(player_team_history entity)
		{
			this.SendPropertyChanging();
			entity.team_tbl = this;
		}
		
		private void detach_player_team_histories(player_team_history entity)
		{
			this.SendPropertyChanging();
			entity.team_tbl = null;
		}
		
		private void attach_player_tbls(player_tbl entity)
		{
			this.SendPropertyChanging();
			entity.team_tbl = this;
		}
		
		private void detach_player_tbls(player_tbl entity)
		{
			this.SendPropertyChanging();
			entity.team_tbl = null;
		}
		
		private void attach_game_tbls(game_tbl entity)
		{
			this.SendPropertyChanging();
			entity.team_tbl = this;
		}
		
		private void detach_game_tbls(game_tbl entity)
		{
			this.SendPropertyChanging();
			entity.team_tbl = null;
		}
		
		private void attach_game_tbls1(game_tbl entity)
		{
			this.SendPropertyChanging();
			entity.team_tbl1 = this;
		}
		
		private void detach_game_tbls1(game_tbl entity)
		{
			this.SendPropertyChanging();
			entity.team_tbl1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.game_tbl")]
	public partial class game_tbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _game_ID;
		
		private int _home_team_ID;
		
		private int _away_team_ID;
		
		private int _score_home;
		
		private int _score_away;
		
		private System.DateTime _date;
		
		private string _location;
		
		private EntitySet<player_stats_tbl> _player_stats_tbls;
		
		private EntityRef<team_tbl> _team_tbl;
		
		private EntityRef<team_tbl> _team_tbl1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ongame_IDChanging(int value);
    partial void Ongame_IDChanged();
    partial void Onhome_team_IDChanging(int value);
    partial void Onhome_team_IDChanged();
    partial void Onaway_team_IDChanging(int value);
    partial void Onaway_team_IDChanged();
    partial void Onscore_homeChanging(int value);
    partial void Onscore_homeChanged();
    partial void Onscore_awayChanging(int value);
    partial void Onscore_awayChanged();
    partial void OndateChanging(System.DateTime value);
    partial void OndateChanged();
    partial void OnlocationChanging(string value);
    partial void OnlocationChanged();
    #endregion
		
		public game_tbl()
		{
			this._player_stats_tbls = new EntitySet<player_stats_tbl>(new Action<player_stats_tbl>(this.attach_player_stats_tbls), new Action<player_stats_tbl>(this.detach_player_stats_tbls));
			this._team_tbl = default(EntityRef<team_tbl>);
			this._team_tbl1 = default(EntityRef<team_tbl>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_game_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int game_ID
		{
			get
			{
				return this._game_ID;
			}
			set
			{
				if ((this._game_ID != value))
				{
					this.Ongame_IDChanging(value);
					this.SendPropertyChanging();
					this._game_ID = value;
					this.SendPropertyChanged("game_ID");
					this.Ongame_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_home_team_ID", DbType="Int NOT NULL")]
		public int home_team_ID
		{
			get
			{
				return this._home_team_ID;
			}
			set
			{
				if ((this._home_team_ID != value))
				{
					if (this._team_tbl1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onhome_team_IDChanging(value);
					this.SendPropertyChanging();
					this._home_team_ID = value;
					this.SendPropertyChanged("home_team_ID");
					this.Onhome_team_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_away_team_ID", DbType="Int NOT NULL")]
		public int away_team_ID
		{
			get
			{
				return this._away_team_ID;
			}
			set
			{
				if ((this._away_team_ID != value))
				{
					if (this._team_tbl.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onaway_team_IDChanging(value);
					this.SendPropertyChanging();
					this._away_team_ID = value;
					this.SendPropertyChanged("away_team_ID");
					this.Onaway_team_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_score_home", DbType="Int NOT NULL")]
		public int score_home
		{
			get
			{
				return this._score_home;
			}
			set
			{
				if ((this._score_home != value))
				{
					this.Onscore_homeChanging(value);
					this.SendPropertyChanging();
					this._score_home = value;
					this.SendPropertyChanged("score_home");
					this.Onscore_homeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_score_away", DbType="Int NOT NULL")]
		public int score_away
		{
			get
			{
				return this._score_away;
			}
			set
			{
				if ((this._score_away != value))
				{
					this.Onscore_awayChanging(value);
					this.SendPropertyChanging();
					this._score_away = value;
					this.SendPropertyChanged("score_away");
					this.Onscore_awayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="Date NOT NULL")]
		public System.DateTime date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this.OndateChanging(value);
					this.SendPropertyChanging();
					this._date = value;
					this.SendPropertyChanged("date");
					this.OndateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_location", DbType="NVarChar(50)")]
		public string location
		{
			get
			{
				return this._location;
			}
			set
			{
				if ((this._location != value))
				{
					this.OnlocationChanging(value);
					this.SendPropertyChanging();
					this._location = value;
					this.SendPropertyChanged("location");
					this.OnlocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="game_tbl_player_stats_tbl", Storage="_player_stats_tbls", ThisKey="game_ID", OtherKey="game_ID")]
		public EntitySet<player_stats_tbl> player_stats_tbls
		{
			get
			{
				return this._player_stats_tbls;
			}
			set
			{
				this._player_stats_tbls.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="team_tbl_game_tbl", Storage="_team_tbl", ThisKey="away_team_ID", OtherKey="team_ID", IsForeignKey=true)]
		public team_tbl team_tbl
		{
			get
			{
				return this._team_tbl.Entity;
			}
			set
			{
				team_tbl previousValue = this._team_tbl.Entity;
				if (((previousValue != value) 
							|| (this._team_tbl.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._team_tbl.Entity = null;
						previousValue.game_tbls.Remove(this);
					}
					this._team_tbl.Entity = value;
					if ((value != null))
					{
						value.game_tbls.Add(this);
						this._away_team_ID = value.team_ID;
					}
					else
					{
						this._away_team_ID = default(int);
					}
					this.SendPropertyChanged("team_tbl");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="team_tbl_game_tbl1", Storage="_team_tbl1", ThisKey="home_team_ID", OtherKey="team_ID", IsForeignKey=true)]
		public team_tbl team_tbl1
		{
			get
			{
				return this._team_tbl1.Entity;
			}
			set
			{
				team_tbl previousValue = this._team_tbl1.Entity;
				if (((previousValue != value) 
							|| (this._team_tbl1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._team_tbl1.Entity = null;
						previousValue.game_tbls1.Remove(this);
					}
					this._team_tbl1.Entity = value;
					if ((value != null))
					{
						value.game_tbls1.Add(this);
						this._home_team_ID = value.team_ID;
					}
					else
					{
						this._home_team_ID = default(int);
					}
					this.SendPropertyChanged("team_tbl1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_player_stats_tbls(player_stats_tbl entity)
		{
			this.SendPropertyChanging();
			entity.game_tbl = this;
		}
		
		private void detach_player_stats_tbls(player_stats_tbl entity)
		{
			this.SendPropertyChanging();
			entity.game_tbl = null;
		}
	}
}
#pragma warning restore 1591
